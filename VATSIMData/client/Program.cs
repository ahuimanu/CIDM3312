using System;
using System.Threading.Tasks;
using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimData;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("VATSIM Library");
            await VatsimDataReader.ProcessVatsimData();
            // VatsimDataHarvester.Run();            
            VatsimDataReader.CurrentVatsimData.ProcessVatsimClientRecords();
            Console.WriteLine($"IFR Pilots with Flight Plans: {VatsimDataReader.CurrentVatsimData.VatsimClientPilots.Count}");
            Console.WriteLine($"ATC: {VatsimDataReader.CurrentVatsimData.VatsimClientATCs.Count}");
        }
    }
}
