import json
import os, uuid
import requests
from azure.storage.blob import BlobServiceClient, BlobClient, ContainerClient
  
# Opening JSON file
f = open('masu.json',)
data = json.load(f)
  
connect_str = 'youstorageconnectionstring'
blob_service_client = BlobServiceClient.from_connection_string(connect_str)
local_path = ".tempdata/"
# Iterating through the json
# list
for i in data:
    # print(i['file'])
    url = i['file']
    r = requests.get(url, allow_redirects=True)
    filename = os.path.basename(url)
    if "fhvhv_" in filename:
        continue
    container_name = filename.replace("fhv_", "").replace("green_", "").replace("yellow_", "").replace(".csv", "").replace("_", "")
    local_file_name = local_path + os.path.basename(url)
    file = open(local_file_name, 'wb')
    file.write(r.content)
    file.close()

    try:
        # Create the container
        container_client = blob_service_client.create_container(container_name)
    except Exception as ex:
        print (ex)
        # pass

    print("\nUploading to Azure Storage as blob:\n\t" + local_file_name)
    blob_client = blob_service_client.get_blob_client(container=container_name, blob=local_file_name)
    # Upload the created file
    with open(local_file_name, "rb") as data:
        blob_client.upload_blob(data)
    
    if os.path.exists(local_file_name):
        os.remove(local_file_name)

# Closing file
f.close()



