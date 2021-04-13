using System;
using System.IO;
using System.Linq;
using TripsAPI.Models;
using TinyCsvParser.Mapping;
using TinyCsvParser;
using System.Text;

namespace TripsAPI.Repositories.Seeders
{
    public static class FilesInPathProcessor
    {
        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory, TripContext context, 
            CsvMapping<TripInfo> csvMapper, IServiceProvider serviceProvider, ServiceType provider)
        {
            // Process the list of files found in the directory.
            string [] fileEntries = Directory.GetFiles(targetDirectory);
            int limit = 100;
            foreach(string fileName in fileEntries){
                ProcessFile(fileName, context, csvMapper, serviceProvider, provider);
                limit --;
                if (limit is 0)
                    break;
            }

        }
        // Insert logic for processing found files here.
        private static void ProcessFile(string path, TripContext context, 
            CsvMapping<TripInfo> csvMapper, IServiceProvider serviceProvider, ServiceType provider)
        {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                CsvParser<TripInfo> csvParser = new CsvParser<TripInfo>(csvParserOptions, csvMapper);

                var result = csvParser
                    .ReadFromFile(path, Encoding.ASCII)
                    .ToList();


                foreach (var tx in result)
                {
                    try{
                        TripsAPI.Process.TripDataProcessor.ComplementInfo(
                            tx.Result, provider, "nyc", "ny", context);
                        context.TripsInfo.AddRange(tx.Result);
                    }
                    catch(NullReferenceException)
                    {
                        // Ommited row that doesn't have a requried column
                    }
                }

                context.SaveChanges();
        }
    }
}