using System.Threading.Tasks;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TripsAPI.Services;
using TripsAPI.Repositories;
using TripsAPI.Models.DTOs;
using TripsAPI.Tests.ContextHelper;


namespace TripsAPI.Tests
{
    class CustomerDataAccessTest
    {
        /// <summary>
        ///  Gets or sets a value of the ITripsService
        /// </summary>
        public ITripsService ITripsService { get; set; }

        /// <summary>
        /// TripsService Service
        /// </summary>
        public TripsService TripsService { get; set; }

        [SetUp]
        public void TestMethodSetup()
        {
            this.ITripsService = Substitute.For<ITripsService>();
            this.TripsService = new TripsService(new MockTripsContext<TripContext>().GetCustomerContext());
        }

        /// <summary>
        /// Validate DIstance Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetDistanceDistributionsTest()
        {
            ////Act 
            List<DistributionGroup> result = await this.TripsService.GetDistanceDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("From5To10".ToLower(), itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetDistanceDistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(8, itemResult.Max);
            Assert.AreEqual(8, itemResult.Mix);
            Assert.AreEqual(100, itemResult.Percentage);
            Assert.AreEqual(8, itemResult.Sum);
            Assert.AreEqual(8, itemResult.Average);
        }

        /// <summary>
        /// Validate Duration Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetDurationDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetDurationDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("greaterthan50", itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("getdurationdistributions", itemResult.DistritutionType.ToLower());
            Assert.AreEqual(60, itemResult.Max);
            Assert.AreEqual(60, itemResult.Mix);
            Assert.AreEqual(100, itemResult.Percentage);
            Assert.AreEqual(60, itemResult.Sum);
            Assert.AreEqual(60, itemResult.Average);
        }

        /// <summary>
        /// Validate Fare Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetFareDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetFareDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("From5To10".ToLower(), itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetFareDistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(5, itemResult.Max);
            Assert.AreEqual(5, itemResult.Mix);
            Assert.AreEqual(100, itemResult.Percentage);
            Assert.AreEqual(5, itemResult.Sum);
            Assert.AreEqual(5, itemResult.Average);
        }

        /// <summary>
        /// Validate Year Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetYearDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetYearDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("2018", itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetYearDistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(100, itemResult.Percentage);
        }

        /// <summary>
        /// Validate Month Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetMonthDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetMonthDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("11", itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetMonthDistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(100, itemResult.Percentage);
        }

        /// <summary>
        /// Validate Day Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetDayDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetDayDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("Tuesday".ToLower(), itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetDayDistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(100, itemResult.Percentage);
        }

        /// <summary>
        /// Validate Hour Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetHourDistributionsTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetHourDistributions(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("11".ToLower(), itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("gethourdistributions".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(100, itemResult.Percentage);
        }

        /// <summary>
        /// Validate Pickup Zones Distributions
        /// </summary>
        [Test]
        public async Task TripsServiceGetTopPickupZonesTest()
        {
            ////Act
            List<DistributionGroup> result = await this.TripsService.GetTopPickupZones(new TripsQuery());

            ////Assert
            Assert.AreEqual(1, result.Count);

            DistributionGroup itemResult = result[0];

            Assert.AreEqual("{ PickUpBorough = Manhattan, PickUpZone = Chelsea }".ToLower(), itemResult.Aggregator.ToLower());
            Assert.AreEqual(1, itemResult.Count);
            Assert.AreEqual("GetTopPickupZones".ToLower(), itemResult.DistritutionType.ToLower());
            Assert.AreEqual(100, itemResult.Percentage);
        }
    }
}
