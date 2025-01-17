using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using TinyCsvParser.Mapping;
using TinyCsvParser;
using TripsDataIngetion.CsvMappers;
using TripsDataIngetion.Models;
using TripsDataIngetion.Process;

namespace TripsDataIngetion
{    public static class nicos_nyctrips_ingestion
    {
        [Function("nicos_nyctrips_ingestion")]
        public static async Task Run([BlobTrigger("datatoingest/{name}", Connection = "nicostripsdata_STORAGE")] string myBlob, string name,
            ILogger logger)
            
        {
            //var logger = context.GetLogger("nicos_nyctrips_ingestion");

            // validate type of file and ft to use 
            if (!name.EndsWith(".csv"))
            {
                return;
            }


            // determine the type of file to load
            ServiceType provider = ServiceType.None;
            CsvMapping<TripInfo> csvMapper = TripsCvsFactory.GetMapper(name, out provider);

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvParser<TripInfo> csvParser = new CsvParser<TripInfo>(csvParserOptions, csvMapper);
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });

            // var result = csvParser.ReadFromStream( (Stream) myBlob, ASCIIEncoding.ASCII).ToList();
            var result = csvParser.ReadFromString( csvReaderOptions, myBlob).ToList();

            string azureSQLConnectionString = Environment.GetEnvironmentVariable("AzureSQL");

            if (result != null && result.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(azureSQLConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        SqlHelper.SqlSetUpTripSqlInsertCmd(cmd);
                        int counter = 1;
                        int saved = 1;
                        foreach (var tx in result)
                        {
                            try
                            {
                                TripDataProcessor.ComplementInfo(tx.Result, provider, "nyc", "ny");

                                SqlHelper.FillParameters(cmd, tx.Result);

                                var rows = await cmd.ExecuteNonQueryAsync();
                                if (rows != 1) {
                                    // Log error 
                                }
                                else saved++;
                                counter++;
                            }
                            catch 
                            {
                            }
                            finally
                            {
                            }
                        }
                    }
                    conn?.Close();
                }
            }   
        }
    }
}
