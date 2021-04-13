using System;
using TripsAPI.Models.DTOs;
using Microsoft.ApplicationInsights;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace TripsAPI.Telemetry
{
    public class TripsCustomTelemetry: ITripsCustomTelemetry
    {
        private TelemetryClient _telemetry;

        public TripsCustomTelemetry(TelemetryClient telemetry){
            _telemetry = telemetry;
        }
        public void TraceCustomEvent(string requestId, string EventName, TripsQuery filters)
        {
            _telemetry.Context.GlobalProperties["x-Request-ID"] = new Guid().ToString();
            _telemetry.Context.GlobalProperties["filters"] = JsonSerializer.Serialize(filters);;
            _telemetry.TrackEvent(EventName);
        }
    }
}