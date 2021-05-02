using System;
using System.Collections.Generic;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public class TrackersDataProcessor : IDataProcessor<TrackerDataFoo1>
    {
        public List<TrackingInfoInternal> ProcessData(TrackerDataFoo1 trackersReading)
        {
            var trackingInfoList = new List<TrackingInfoInternal>();
            foreach (var item in trackersReading.Trackers)
            {
                var trackerId = Guid.NewGuid().ToString();
                foreach (var sensor in item.Sensors)
                {
                    foreach (var crumb in sensor.Crumbs)
                    {
                        var trackingInfo = new TrackingInfoInternal();
                        trackingInfo.InternalTrackerId = trackerId;
                        trackingInfo.TrackerId = item.Id;
                        trackingInfo.TrackerName = item.Model;
                        trackingInfo.CompanyId = trackersReading.PartnerId;
                        trackingInfo.CompanyName = trackersReading.PartnerName;

                        trackingInfo.SensorType = sensor.Name == SensorType.Temperature.ToString() ? SensorType.Temperature : SensorType.Humidty;
                        trackingInfo.SensorValue = crumb.Value;
                        DateTime.TryParse(crumb.CreatedDtm, out DateTime reportedOn);
                        trackingInfo.ReportedOn = reportedOn;
                        trackingInfoList.Add(trackingInfo);
                    }
                }
            }

            return trackingInfoList;
        }
    }
}
