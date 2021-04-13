Install azure blob storage SDK for Python

`pip install azure-storage-blob`

Set an environment variable with you connection string `export AZURE_STORAGE_CONNECTION_STRING="<yourconnectionstring>"`


1. Run python 3 on main.py to split CSV in X amount of roles
2. Run data_transfer.py to read from masu.json file all .cvs files to tranfer to an Azure blob storage account.