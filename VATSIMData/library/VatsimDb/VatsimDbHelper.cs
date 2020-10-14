using System;
using System.Linq;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimDb
{
    public class VatsimDbHepler
    {

        public static void UpdateOrCreateATC(VatsimClientATC controller)
        {

            using(var db = new VatsimDbContext())
            {

                var _controller = db.Controllers.Find(controller.Cid, controller.Callsign, controller.TimeLogon);

                // didn't find the pilot
                if(_controller == null)
                {
                    db.Add(controller);
                    db.SaveChanges();
                }
                else
                {
                    DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_controller.TimeLogon);
                    DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(controller.TimeLogon);
                    if(new_time > old_time)
                    {
                        db.Add(controller);
                        db.SaveChanges();                        
                    }
                    else
                    {
                        _controller.Update(controller);
                        db.SaveChanges();
                    }
                }
            }
        }

        public static void UpdateOrCreatePilot(VatsimClientPilot pilot)
        {

            using(var db = new VatsimDbContext())
            {

                var _pilot = db.Pilots.Find(pilot.Cid, pilot.Callsign, pilot.TimeLogon);

                // didn't find the pilot
                if(_pilot == null)
                {
                    db.Add(pilot);
                    db.SaveChanges();
                }
                else
                {
                    DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_pilot.TimeLogon);
                    DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(pilot.TimeLogon);
                    if(new_time > old_time)
                    {
                        db.Add(pilot);
                        db.SaveChanges();                        
                    }
                    else
                    {
                        _pilot.Update(pilot);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}