using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TinyCsvParser;

using TripsAPI.Models;

namespace TripsAPI.Repositories.Seeders
{
    public static class TripSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new TripContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TripContext>>()))
            {
                if (context.TaxiZones.Any() is false)
                {                   
                    CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                    TaxiZoneMapping csvMapper = new TaxiZoneMapping();
                    CsvParser<TaxiZone> csvParser = new CsvParser<TaxiZone>(csvParserOptions, csvMapper);

                    // TODO Add path to config
                    var result = csvParser
                        .ReadFromFile(@"Repositories/SeedProcessor/Data/taxi+_zone_lookup.csv", Encoding.ASCII)
                        .ToList();


                    foreach (var tx in result)
                    {
                        context.TaxiZones.AddRange(tx.Result);
                    }

                    context.SaveChanges();
                }

            }

            using (var context = new TripContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TripContext>>()))
            {
                if (context.TripsInfo.Any())
                {
                    return;   // DB has been seeded
                }
                
                GreenMapping greenMapper = new GreenMapping();
                FilesInPathProcessor.ProcessDirectory(@"Repositories/SeedProcessor/Data/.green",context, greenMapper, serviceProvider, ServiceType.Green);

                YellowMapping yellowMapper = new YellowMapping();
                FilesInPathProcessor.ProcessDirectory(@"Repositories/SeedProcessor/Data/.yellow",context, yellowMapper, serviceProvider, ServiceType.Yellow);

                FhvMapping FhvMapper = new FhvMapping();
                FilesInPathProcessor.ProcessDirectory(@"Repositories/SeedProcessor/Data/.fhv",context, FhvMapper, serviceProvider, ServiceType.FHV);
            }
        }
    }
}