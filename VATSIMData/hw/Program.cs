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

                var _pilots = db.Pilots.Select(p => p).ToList();
                Console.WriteLine($"The number of pilots records is: {_pilots.Count} ");

                //1238470                
                //UAL2865
                //20201013162413
                var _pilot = db.Pilots.Find("1238470", "UAL2865", "20201013162413");                
                if(_pilot != null){
                    Console.WriteLine($"Pilot found: {_pilot.Realname}");
                } else {
                    Console.WriteLine("Pilot not found");
                }                

                //1385451
                //N130JM
                //20201021233811
                _pilot = db.Pilots.Find("1385451", "N130JM", "20201021233811");
                if(_pilot != null){
                    Console.WriteLine($"Pilot found: {_pilot.Realname}");
                } else {
                    Console.WriteLine("Pilot not found");
                }                                
            }            
        }
    }
}
