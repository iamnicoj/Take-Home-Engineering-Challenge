using Microsoft.EntityFrameworkCore;
using TripsAPI.Models;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TripsAPI.Repositories
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {
        }

        public DbSet<TaxiZone> TaxiZones { get; set; }
        public DbSet<TripInfo> TripsInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var serviceTypeConverter = new ValueConverter<ServiceType, string>(
                    v => v.ToString(),
                    v => (ServiceType)Enum.Parse(typeof(ServiceType), v));

            modelBuilder.Entity<TripInfo>()
                .Property(e => e.Operator)
                .HasConversion(serviceTypeConverter);

            var DurationRangeConverter = new ValueConverter<DurationRange, string>(
                    v => v.ToString(),
                    v => (DurationRange)Enum.Parse(typeof(DurationRange), v));

            modelBuilder.Entity<TripInfo>()
                .Property(e => e.DurationRange)
                .HasConversion(DurationRangeConverter);

            var DistanceTypeConverter = new ValueConverter<DistanceRange, string>(
                    v => v.ToString(),
                    v => (DistanceRange)Enum.Parse(typeof(DistanceRange), v));

            modelBuilder.Entity<TripInfo>()
                .Property(e => e.DistanceRange)
                .HasConversion(DistanceTypeConverter);

            var FareRangeTypeConverter = new ValueConverter<FareRange, string>(
                    v => v.ToString(),
                    v => (FareRange)Enum.Parse(typeof(FareRange), v));

            modelBuilder.Entity<TripInfo>()
                .Property(e => e.FareRange)
                .HasConversion(FareRangeTypeConverter);

            modelBuilder.Entity<TripInfo>()
                .Property(p => p.Duration)
                .HasComputedColumnSql("DATEDIFF(minute, [PickupDateTime], [DropOffDateTime])", stored: true);

            modelBuilder.Entity<TripInfo>()
                .Property(p => p.Year)
                .HasComputedColumnSql("DATEPART(YYYY,[PickupDateTime])", stored: true);

            modelBuilder.Entity<TripInfo>()
                .Property(p => p.Month)
                .HasComputedColumnSql("DATEPART(m,[PickupDateTime])", stored: true);

            modelBuilder.Entity<TripInfo>()
                .Property(p => p.Hour)
                .HasComputedColumnSql("DATEPART(HOUR,[PickupDateTime])", stored: true);
        }
    }
}