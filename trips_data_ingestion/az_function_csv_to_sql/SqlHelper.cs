using System;
using System.Data;
using Microsoft.Data.SqlClient;
using TripsDataIngetion.Models;

namespace TripsDataIngetion
{
    public static class SqlHelper
    {
        public static void SqlSetUpTripSqlInsertCmd(SqlCommand cmd)
        {
            cmd.CommandText = @"INSERT INTO 
                dbo.TripsInfo (Id, State, City, PickupDateTime, WeekDay, DropOffDateTime, PassangerCount, 
                PaymentType, Fare, FareRange, Distance, DistanceRange, DurationRange, Operator, DropOffZoneId, PickUpZoneId) 
                VALUES (@Id, @State, @City, @PickupDateTime, @WeekDay, @DropOffDateTime, @PassangerCount, 
                @PaymentType, @Fare, @FareRange , @Distance, @DistanceRange, @DurationRange, @Operator, @DropOffZoneId, @PickUpZoneId);";

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
            cmd.Parameters.Add(new SqlParameter("@State", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@PickupDateTime", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@WeekDay", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@DropOffDateTime", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@PassangerCount", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@PaymentType", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@Fare", SqlDbType.Decimal));
            cmd.Parameters.Add(new SqlParameter("@FareRange", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@Distance", SqlDbType.Decimal));
            cmd.Parameters.Add(new SqlParameter("@DistanceRange", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@DurationRange", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@Operator", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@DropOffZoneId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@PickUpZoneId", SqlDbType.Int));
        }

        public static void FillParameters(SqlCommand cmd, TripInfo trip)
        {
            cmd.Parameters["@Id"].Value = new System.Data.SqlTypes.SqlGuid(Guid.NewGuid());// Guid.NewGuid().ToString();
            cmd.Parameters["@State"].Value = nulltostring(trip.State);
            cmd.Parameters["@City"].Value = nulltostring(trip.City);
            cmd.Parameters["@PickupDateTime"].Value = trip.PickupDateTime;
            cmd.Parameters["@WeekDay"].Value = nulltostring(trip.WeekDay);
            cmd.Parameters["@DropOffDateTime"].Value = trip.DropOffDateTime;
            cmd.Parameters["@PassangerCount"].Value = trip.PassangerCount;
            cmd.Parameters["@PaymentType"].Value = trip.PaymentType;
            cmd.Parameters["@Fare"].Value = trip.Fare;
            cmd.Parameters["@FareRange"].Value = trip.FareRange.ToString();
            cmd.Parameters["@Distance"].Value = trip.Distance;
            cmd.Parameters["@DistanceRange"].Value = trip.DistanceRange.ToString();
            cmd.Parameters["@DurationRange"].Value = trip.DurationRange.ToString();
            cmd.Parameters["@Operator"].Value = trip.Operator.ToString();
            cmd.Parameters["@DropOffZoneId"].Value = trip.DropOffZoneId;
            cmd.Parameters["@PickUpZoneId"].Value = trip.PickUpZoneId;
        }

        private static string nulltostring(object Value)
        {
            return Value == null ? "" : Value.ToString();
        }
    }
}