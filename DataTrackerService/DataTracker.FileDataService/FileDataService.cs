using System.IO;
using System.Text.Json;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public class FileDataService : IFileDataService
    {
        public TrackerDataFoo1 GetTrackersReading()
        {
            var fileAsText = File.ReadAllText(@"TrackingInfo\TrackerDataFoo1.json");
            return JsonSerializer.Deserialize<TrackerDataFoo1>(fileAsText);
        }

        public TrackerDataFoo2 GetDevicesReading()
        {
            var fileAsText = File.ReadAllText(@"TrackingInfo\TrackerDataFoo2.json");
            return JsonSerializer.Deserialize<TrackerDataFoo2>(fileAsText);
        }
    }
}
