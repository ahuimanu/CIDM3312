using System;
using System.Threading.Tasks;
using VatsimLibrary;
using VatsimLibrary.Data;

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
