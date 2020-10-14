using System;
using System.Timers;

using VatsimLibrary.VatsimClient;

namespace VatsimLibrary.VatsimData
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=netcore-3.1
    /// </summary>
    public class VatsimDataHarvester
    {

        private const int INTERVAL = 2 * 1000;
        private static Timer clock { get; set; }

        public static void Run()
        {

            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine($"The application started at {DateTime.Now:HH:mm:ss.fff}");
            Console.ReadLine();
            clock.Stop();
            clock.Dispose();
            
            Console.WriteLine("Terminating the application...");}

        private static void SetTimer()
        {
            clock = new Timer(INTERVAL);
            clock.Elapsed += HarvestData;
            clock.AutoReset = true;
            clock.Enabled = true;            
        }

        private static void HarvestData(Object source, ElapsedEventArgs eea)
        {
            Console.WriteLine($"triggered at: {eea.SignalTime:HH:mm:ss.fff}");
        }

    }
}