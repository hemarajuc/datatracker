using System.Collections.Generic;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public interface IDataProcessor<T>
    {
        List<TrackingInfoInternal> ProcessData(T reading);
    }
}
