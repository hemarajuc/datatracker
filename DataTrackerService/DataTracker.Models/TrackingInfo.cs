using System;

namespace DeviceTracker.Models
{
    public class TrackingInfo
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? TrackerId { get; set; }
        public string TrackerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FirstCrumbDtm { get; set; }
        public DateTime? LastCrumbDtm { get; set; }
        public int? TempCount { get; set; }
        public double? AvgTemp { get; set; }
        public int? HumidityCount { get; set; }
        public double? AvgHumidity { get; set; }
    }

    public class TrackingInfoInternal : TrackingInfo
    {
        public SensorType SensorType { get; set; }
        public double SensorValue { get; set; }
        public DateTime? ReportedOn { get; set; }
        public string InternalTrackerId { get; set; }
    }

    public enum SensorType
    {
        Temperature,
        Humidty
    }
}
