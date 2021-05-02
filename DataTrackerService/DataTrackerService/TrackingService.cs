using System.Linq;
using DeviceTracker.Models;

namespace DeviceTrackerService
{
    public class TrackingService : ITrackingService
    {
        private readonly IFileDataService _fileProcessingService;
        private readonly IDataProcessor<TrackerDataFoo1> _trackersDataProcessor;
        private readonly IDataProcessor<TrackerDataFoo2> _devicesDataProcessor;
        private readonly ITrackingAggregator _trackingAggregator;

        public TrackingService(IFileDataService fileProcessingService, IDataProcessor<TrackerDataFoo1> trackersDataProcessor, IDataProcessor<TrackerDataFoo2> devicesDataProcessor, ITrackingAggregator trackingAggregator)
        {
            _fileProcessingService = fileProcessingService;
            _trackersDataProcessor = trackersDataProcessor;
            _devicesDataProcessor = devicesDataProcessor;
            _trackingAggregator = trackingAggregator;
        }

        public TrackingInfo[] GetTrackingInformation()
        {
            var trackersReading = _fileProcessingService.GetTrackersReading();
            var devicesReading = _fileProcessingService.GetDevicesReading();

            var trackersProcessedReadings = _trackersDataProcessor.ProcessData(trackersReading);
            var devicesProcessedReadings = _devicesDataProcessor.ProcessData(devicesReading);

            return _trackingAggregator.Aggregate(trackersProcessedReadings, devicesProcessedReadings).ToArray();
        }
    }
}
