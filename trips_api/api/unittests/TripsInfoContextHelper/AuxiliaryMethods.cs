using System;
using TripsAPI.Models;

namespace TripsAPI.Tests.ContextHelper
{
    public static class AuxiliaryMethods
    {

        public static void ComplementInfo(
        TripInfo trip, ServiceType provider, string city, string state)
        {
            trip.City = city;
            trip.State = state;

            trip.Operator = provider;
            trip.DistanceRange = TripDistanceRange(trip.Distance);
            trip.FareRange = TripFareRange(trip.Fare);

            TimeSpan ts = trip.DropOffDateTime - trip.PickupDateTime;
            trip.DurationRange = TripDurationRange(ts.TotalMinutes);
            trip.Duration = Convert.ToInt32(ts.TotalMinutes);

            trip.WeekDay = trip.PickupDateTime.DayOfWeek.ToString();
            trip.Hour = trip.PickupDateTime.Hour;
            trip.Year = trip.PickupDateTime.Year;
            trip.Month = trip.PickupDateTime.Month;

            trip.PickUpZone = "Chelsea";
            trip.PickUpBorough = "Manhattan";
            trip.DropOffZone = "Harlem";
            trip.DropOffBorough = "Manhattan";
        }


        private static DurationRange TripDurationRange(double distance) => distance switch
        {
            <= 0 => DurationRange.Just0,
            < 5 => DurationRange.From0To5,
            < 15 => DurationRange.From5To15,
            < 25 => DurationRange.From15To25,
            < 35 => DurationRange.From25To35,
            < 50 => DurationRange.From35o50,
            _ => DurationRange.GreaterThan50,
        };

        private static DistanceRange TripDistanceRange(decimal distance) => distance switch
        {
            <= 0 => DistanceRange.Just0,
            < 2 => DistanceRange.From0To2,
            < 5 => DistanceRange.From2To5,
            < 10 => DistanceRange.From5To10,
            < 15 => DistanceRange.From10To15,
            < 20 => DistanceRange.From15o20,
            _ => DistanceRange.GreaterThan20,
        };

        private static FareRange TripFareRange(decimal fare) => fare switch
        {
            <= 0 => FareRange.Just0,
            < 5 => FareRange.From0To5,
            < 10 => FareRange.From5To10,
            < 15 => FareRange.From10To15,
            < 20 => FareRange.From15o20,
            < 30 => FareRange.From20to30,
            < 50 => FareRange.From30to50,
            < 80 => FareRange.From50to80,
            _ => FareRange.GreaterThan80,
        };
    }

}