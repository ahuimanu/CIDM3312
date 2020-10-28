using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Serilog;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimDb
{
    public class VatsimDbHepler
    {

        public static readonly string DATA_DIR;

        static VatsimDbHepler()
        {
            DirectoryInfo data_dir = new DirectoryInfo(Environment.CurrentDirectory);
            DATA_DIR = $@"{data_dir.Parent}\data\";
        }

        public static async void UpdateOrCreateATC(VatsimClientATC controller)
        {

            using(var db = new VatsimDbContext())
            {

                var _controller = await db.Controllers.FindAsync(controller.Cid, controller.Callsign, controller.TimeLogon);

                // didn't find the pilot
                if(_controller == null)
                {
                    db.Add(controller);
                    db.SaveChanges();
                    Log.Information($"Added Controller: {controller} to DB");                    
                }
                else
                {
                    DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_controller.TimeLogon);
                    DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(controller.TimeLogon);
                    if(new_time > old_time)
                    {
                        db.Add(controller);
                        Log.Information($"Added Controller: {controller} to DB");
                        db.SaveChanges();       
                    }
                    else
                    {
                        _controller.Update(controller);
                        db.Update(_controller);
                        db.SaveChanges();
                        Log.Information($"Updated Controller: {controller} in DB");
                    }
                }
            }
        }

        public static async void UpdateOrCreatePilot(VatsimClientPilot pilot)
        {

            using(var db = new VatsimDbContext())
            {

                var _pilot = await db.Pilots.FindAsync(pilot.Cid, pilot.Callsign, pilot.TimeLogon);

                // didn't find the pilot
                if(_pilot == null)
                {
                    db.Add(pilot);
                    db.SaveChanges();
                    Log.Information($"Added Pilot: {pilot} to DB");
                }
                else
                {
                    DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_pilot.TimeLogon);
                    DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(pilot.TimeLogon);
                    if(new_time > old_time)
                    {
                        db.Add(pilot);
                        db.SaveChanges();
                        Log.Information($"Added Pilot: {pilot} to DB");                             
                    }
                    else
                    {
                        _pilot.Update(pilot);
                        db.Update(_pilot);
                        db.SaveChanges();
                        Log.Information($"Updated Pilot: {pilot} in DB");
                    }
                }
            }
        }

        public static async void UpdateOrCreateFlight(VatsimClientPlannedFlight flight)
        {

            using(var db = new VatsimDbContext())
            {
                var _flight = await db.Flights.FindAsync(flight.Cid, 
                                                         flight.Callsign,
                                                         flight.TimeLogon, 
                                                         flight.PlannedDepairport, 
                                                         flight.PlannedDestairport);

                // didn't find the pilot
                if(_flight == null)
                {
                    // log.Info($"Adding flight to DB: {flight.ToString()}");
                    db.Add(flight);
                    db.SaveChanges();
                    Log.Information($"Added Flight: {flight} to DB");                    
                }
                else
                {
                    // log.Info($"Flight found in DB: {_flight.ToString()}");
                    DateTime old_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(_flight.TimeLogon);
                    DateTime new_time = VatsimDataState.GetDateTimeFromVatsimTimeStamp(flight.TimeLogon);
                    if(new_time > old_time)
                    {
                        db.Add(flight);
                        db.SaveChanges();
                        Log.Information($"Added Flight: {flight} to DB");
                    }
                    else
                    {
                        _flight.Update(flight);
                        db.Update(_flight);
                        db.SaveChanges();
                        Log.Information($"Updated Flight: {flight} in DB");
                    }
                }
            }
        }

        /// <summary>
        /// Save a position to the database
        /// </summary>
        /// <param name="position">position snapshot information</param>
        public static void CreatePosition(VatsimClientPilotSnapshot position)
        {

            using(var db = new VatsimDbContext())
            {
                // make sure we have a position to write
                if(position != null)
                {
                    db.Add(position);
                    db.SaveChanges();
                    Log.Information($"Added Position: {position} to DB");
                }
            }
        }
    }
}