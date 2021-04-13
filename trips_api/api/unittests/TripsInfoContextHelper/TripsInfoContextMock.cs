using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TripsAPI.Repositories;
using TripsAPI.Models;

namespace TripsAPI.Tests.ContextHelper
{
    /// <summary>
    /// Customer Entity Mock
    /// </summary>
    /// <typeparam name="T">Fake entity context</typeparam>
    public class MockTripsContext<T>
    {
        /// <summary>
        /// Get Customer context mock object
        /// </summary>
        /// <returns>Context object</returns>
        public TripContext GetCustomerContext()
        {
            var options = new DbContextOptionsBuilder<TripContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            var context = new TripContext(options);

            TripInfo trip1 = new TripInfo { 
                Distance = 8,
                DistanceRange = DistanceRange.From5To10,
                DropOffDateTime =  Convert.ToDateTime("2018-11-20T12:11:11"),
                DropOffZoneId = 11,
                Fare = 5,
                PassangerCount = 3,
                PaymentType = 1,
                PickupDateTime = Convert.ToDateTime("2018-11-20T11:11:11"),
                PickUpZoneId = 2,
            };

            AuxiliaryMethods.ComplementInfo(trip1, ServiceType.Green, "nyc", "ny");

            context.TripsInfo.Add(trip1);
            context.SaveChanges();
            return context;
        }
    }
}
