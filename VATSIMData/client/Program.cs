using System;
using System.Threading.Tasks;
using VatsimLibrary;

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
