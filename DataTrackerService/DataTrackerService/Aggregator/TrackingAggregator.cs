using System;
using System.Collections.Generic;
using System.Linq;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public class TrackingAggregator : ITrackingAggregator
    {
        public IEnumerable<TrackingInfo> Aggregate(params List<TrackingInfoInternal>[] trackingInfoInternals)
        {
            var result = trackingInfoInternals.SelectMany(x => x)
               .GroupBy(x => new { x.InternalTrackerId, x.TrackerId, x.TrackerName, x.CompanyId, x.CompanyName })
               .Select(y => new TrackingInfo
               {
                   TrackerName = y.Key.TrackerName,
                   TrackerId = y.Key.TrackerId,
                   CompanyId = y.Key.CompanyId,
                   CompanyName = y.Key.CompanyName,
                   TempCount = y.Where(z => z.SensorType == SensorType.Temperature)?.Count(),
                   HumidityCount = y.Where(z => z.SensorType == SensorType.Humidty)?.Count(),
                   AvgTemp = y.Any(z => z.SensorType == SensorType.Temperature) ? Math.Round(y.Where(z => z.SensorType == SensorType.Temperature).Average(x => x.SensorValue), 2, MidpointRounding.ToEven) : 0,
                   AvgHumidity = y.Any(z => z.SensorType == SensorType.Humidty) ? Math.Round(y.Where(z => z.SensorType == SensorType.Humidty).Average(x => x.SensorValue), 2, MidpointRounding.ToEven) : 0,
                   FirstCrumbDtm = y.Min(z => z.ReportedOn),
                   LastCrumbDtm = y.Max(z => z.ReportedOn)
               });

            return result;
        }
    }
}
