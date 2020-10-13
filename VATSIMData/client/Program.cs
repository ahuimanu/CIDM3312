using System;
using System.Threading.Tasks;
using VatsimLibrary;
using VatsimLibrary.VatsimData;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("VATSIM Library");
            await VatsimDataReader.ProcessVatsimData();
        }
    }
}
