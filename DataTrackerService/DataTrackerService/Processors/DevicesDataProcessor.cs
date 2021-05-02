using System;
using System.Collections.Generic;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public class DevicesDataProcessor : IDataProcessor<TrackerDataFoo2>
    {
        public List<TrackingInfoInternal> ProcessData(TrackerDataFoo2 devicesReading)
        {
            var trackingInfoList = new List<TrackingInfoInternal>();
            foreach (var device in devicesReading.Devices)
            {
                var trackerId = Guid.NewGuid().ToString();
                foreach (var sensor in device.SensorData)
                {
                    var trackingInfo = new TrackingInfoInternal();
                    trackingInfo.InternalTrackerId = trackerId;
                    trackingInfo.TrackerId = device.DeviceID;
                    trackingInfo.TrackerName = device.Name;
                    trackingInfo.CompanyId = devicesReading.CompanyId;
                    trackingInfo.CompanyName = devicesReading.Company;

                    trackingInfo.SensorType = sensor.SensorType == Constants.Temperature ? SensorType.Temperature : SensorType.Humidty;

                    trackingInfo.SensorValue = sensor.Value;
                    DateTime.TryParse(sensor.DateTime, out DateTime reportedOn);
                    trackingInfo.ReportedOn = reportedOn;
                    trackingInfoList.Add(trackingInfo);
                }
            }

            return trackingInfoList;
        }
    }
}
