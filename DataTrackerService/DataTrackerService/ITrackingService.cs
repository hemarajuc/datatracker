using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public interface ITrackingService
    {
        TrackingInfo[] GetTrackingInformation();
    }
}