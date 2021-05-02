using System.Collections.Generic;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public interface ITrackingAggregator
    {
        IEnumerable<TrackingInfo> Aggregate(params List<TrackingInfoInternal>[] trackingInfoInternals);
    }
}
