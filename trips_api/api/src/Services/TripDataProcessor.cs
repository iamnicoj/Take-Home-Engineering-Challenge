using System;
using System.Linq;
using System.Collections.Generic;
using TripsAPI.Models;
using TripsAPI.Repositories;


namespace TripsAPI.Process
{
    public static class TripDataProcessor
    {
        private static List<TaxiZone> _zones;

        public static void ComplementInfo(
            TripInfo trip, ServiceType provider, string city, string state, TripContext context)
        {
            if(_zones is null || _zones.Count == 0)
                LoadZones(context);

            trip.City = city;
            trip.State = state;

            trip.Operator = provider;
            trip.DistanceRange = TripDistanceRange(trip.Distance);
            trip.FareRange = TripFareRange(trip.Fare);

            TimeSpan ts = trip.DropOffDateTime - trip.PickupDateTime;
            trip.DurationRange = TripDurationRange(ts.TotalMinutes);

            trip.WeekDay = trip.PickupDateTime.DayOfWeek.ToString();

            var puZone = _zones.Find(p => p.TaxiZoneId == trip.PickUpZoneId);
            if( puZone is not null)
                trip.PickUpBorough = puZone.Borough;
                trip.PickUpZone = puZone.Zone;

            var dpZone = _zones.Find(p => p.TaxiZoneId == trip.DropOffZoneId);
            if( puZone is not null)
                trip.DropOffBorough = dpZone.Borough;
                trip.DropOffZone = dpZone.Zone;
        }

        private static void LoadZones(TripContext context)
        { 
            _zones = context.TaxiZones.ToList();
        }

        private static DurationRange TripDurationRange(double distance) => distance switch
        {
            <= 0 =>  DurationRange.Just0,
            < 5 =>  DurationRange.From0To5,
            < 15 =>  DurationRange.From5To15,
            < 25 =>  DurationRange.From15To25,
            < 35 =>  DurationRange.From25To35,
            < 50 =>  DurationRange.From35o50,
            _ =>    DurationRange.GreaterThan50,
        };

        private static DistanceRange TripDistanceRange(decimal distance) => distance switch
        {
            <= 0 =>  DistanceRange.Just0,
            < 2 =>  DistanceRange.From0To2,
            < 5 =>  DistanceRange.From2To5,
            < 10 =>  DistanceRange.From5To10,
            < 15 =>  DistanceRange.From10To15,
            < 20 =>  DistanceRange.From15o20,
            _ =>    DistanceRange.GreaterThan20,
        };

        private static FareRange TripFareRange(decimal fare) => fare switch
        {
            <= 0 =>  FareRange.Just0,
            < 5 =>  FareRange.From0To5,
            < 10 =>  FareRange.From5To10,
            < 15 =>  FareRange.From10To15,
            < 20 =>  FareRange.From15o20,
            < 30 =>  FareRange.From20to30,
            < 50 =>  FareRange.From30to50,
            < 80 =>  FareRange.From50to80,
            _ =>    FareRange.GreaterThan80,
        };
    }

}