using System.Collections.Generic;
using DeviceTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DeviceTrackerService.Tests
{
    [TestClass]
    public class TrackingServiceTests
    {
        [TestMethod]
        public void TestTrackingDataWithTwoDevices_TrackedSuccessfully()
        {
            var fileDataService = new Mock<IFileDataService>();
            var trackersDataProcessor = new Mock<IDataProcessor<TrackerDataFoo1>>();
            var devicesDataProcessor = new Mock<IDataProcessor<TrackerDataFoo2>>();
            var trackingAggregator = new Mock<ITrackingAggregator>();
            var trackerDataFoo1 = new TrackerDataFoo1();
            var trackerDataFoo2 = new TrackerDataFoo2();
            var trackersProcessedReadings = new List<TrackingInfoInternal>();
            var devicesProcessedReadings = new List<TrackingInfoInternal>();
            fileDataService.Setup(x => x.GetTrackersReading()).Returns(trackerDataFoo1);
            fileDataService.Setup(x => x.GetDevicesReading()).Returns(trackerDataFoo2);
            trackersDataProcessor.Setup(x => x.ProcessData(It.IsAny<TrackerDataFoo1>())).Returns(trackersProcessedReadings);
            devicesDataProcessor.Setup(x => x.ProcessData(It.IsAny<TrackerDataFoo2>())).Returns(devicesProcessedReadings);
            trackingAggregator.Setup(x => x.Aggregate(It.IsAny<List<TrackingInfoInternal>[]>())).Returns(new List<TrackingInfo>());

            var trackingService = new TrackingService(fileDataService.Object, trackersDataProcessor.Object, devicesDataProcessor.Object, trackingAggregator.Object);
            trackingService.GetTrackingInformation();
            fileDataService.Verify(x => x.GetTrackersReading(), Times.Once);
            fileDataService.Verify(x => x.GetDevicesReading(), Times.Once);
            trackersDataProcessor.Verify(x => x.ProcessData(It.IsAny<TrackerDataFoo1>()), Times.Once);
            devicesDataProcessor.Verify(x => x.ProcessData(It.IsAny<TrackerDataFoo2>()), Times.Once);
            trackingAggregator.Verify(x => x.Aggregate(It.IsAny<List<TrackingInfoInternal>[]>()), Times.Once);
        }
    }
}
