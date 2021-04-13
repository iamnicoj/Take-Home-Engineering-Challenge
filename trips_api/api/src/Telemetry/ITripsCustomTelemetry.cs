using TripsAPI.Models.DTOs;


namespace TripsAPI.Telemetry
{
    public interface ITripsCustomTelemetry
    {
        void TraceCustomEvent(string requestId, string EventName, TripsQuery filters);
    }
}