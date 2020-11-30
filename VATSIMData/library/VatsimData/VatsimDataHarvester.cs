using System;
using Timers = System.Timers;
using System.Threading;

namespace VatsimLibrary.VatsimData
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=netcore-3.1
    /// @deprecated { this works outside of the asp.net proces as a stand-alone. However, we'd want to collect this information continuously
    /// while the server is running.}
    /// </summary>
    public class VatsimDataHarvester
    {

        private const int INTERVAL = 120 * 1000;
        private static Timers.Timer clock { get; set; }

        public static void Run(DateTime stop)
        {

            SetTimer();
            //run the first time
            DoHarvest();
            Console.WriteLine($"The application started at {DateTime.Now:HH:mm:ss.fff}");
            // Console.ReadLine();
            while(DateTime.Now <= stop)
            {
                Thread.Sleep(1000);
            }            
            clock.Stop();
            clock.Dispose();
            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            clock = new System.Timers.Timer(INTERVAL);
            clock.Elapsed += HarvestData;
            clock.AutoReset = true;
            clock.Start();
        }

        public static async void DoHarvest()
        {
            Console.WriteLine($"Starting: {DateTime.UtcNow.ToLongTimeString()}");

            await VatsimDataReader.ProcessVatsimData();
            // VatsimDataReader.CurrentVatsimData.ProcessVatsimClientRecords();
            await VatsimDataReader.CurrentVatsimData.BatchProcessVatsimClientRecords();
            
            Console.WriteLine($"Completed: {DateTime.UtcNow.ToLongTimeString()}");
        }

        private static void HarvestData(Object source, System.Timers.ElapsedEventArgs eea)
        {
            Console.WriteLine($"triggered at: {eea.SignalTime:HH:mm:ss.fff}");
            DoHarvest();
        }
    }
}