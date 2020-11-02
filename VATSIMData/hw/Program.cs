using System;
using System.IO;
using System.Linq;

using VatsimLibrary.VatsimClientV1;
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

                var _pilots = db.Pilots.Select(p => p).ToList();
                Console.WriteLine($"The number of pilots records is: {_pilots.Count} ");

                //find A319
                var _aircraft = db.Flights.Where(f => f.PlannedAircraft.Contains("A319"));
                Console.WriteLine($"It is likely that there are {_aircraft.Count()} A319s in the data");

                _aircraft = db.Flights.Where(f => f.PlannedAircraft.Contains("B738"));
                Console.WriteLine($"It is likely that there are {_aircraft.Count()} B738s in the data");                
            }            
        }

        public static void FindPilot(VatsimDbContext db, string cid, string callsign, string logontime)
        {
            var _pilot = db.Pilots.Find(cid, callsign, logontime);
            if(_pilot != null){
                Console.WriteLine($"Pilot found: {_pilot.Realname}");
            } else {
                Console.WriteLine("Pilot not found");
            }            
        }
    }
}
