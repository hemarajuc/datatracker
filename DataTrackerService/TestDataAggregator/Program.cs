using System;
using System.Text.Json;
using DeviceTrackerService;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var trackingService = GetTrackingService();
            var result = trackingService.GetTrackingInformation();
            Console.WriteLine(JsonSerializer.Serialize(result));
            Console.WriteLine("Successfully aggregated tracking information.");
            Console.ReadLine();
        }

        private static ITrackingService GetTrackingService()
        {
            return new TrackingService(new FileDataService(), new TrackersDataProcessor(), new DevicesDataProcessor(), new TrackingAggregator());
        }
    }
}
