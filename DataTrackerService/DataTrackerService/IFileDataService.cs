using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public interface IFileDataService
    {
        TrackerDataFoo1 GetTrackersReading();

        TrackerDataFoo2 GetDevicesReading();
    }
}