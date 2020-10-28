using System;
using System.IO;
using System.Linq;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimDb;

namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{VatsimDbHepler.DATA_DIR}");

            using(var db = new VatsimDbContext())
            {
                //UAL2865
                //1238470
                //20201013162413
                var stuff = db.Pilots.Select(p => p).ToList();
                Console.WriteLine($"The number of pilots records is: {stuff.Count} ");
                var _pilot = db.Pilots.Find("1238470", "UAL2865", "20201013162413");
                if(_pilot != null){
                    Console.WriteLine($"Pilot found: {_pilot.Realname}");
                } else {
                    Console.WriteLine("Pilot not found");
                }
            }            
        }
    }
}
