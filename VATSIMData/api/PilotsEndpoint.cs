using System;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;


using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;


namespace api
{
    public class PilotsEndpoint
    {
        public static async Task CallsignEndpoint(HttpContext context)
        {
            string responseText = null;
            string callsign = context.Request.RouteValues["callsign"] as string;


            using(var db = new VatsimDbContext())
            {
                if(callsign != null)
                {
                    Console.WriteLine($"{callsign}");

                    var _cid = await db.Pilots.Where(p => p.Callsign == callsign).ToListAsync();

                    // var _departure = await db.Flights.Where(f => f.PlannedDepairport == (flightDeparture ?? "").ToUpper()).ToListAsync();
                    responseText = $"It is likely that at least {_cid.Count()} pilots have used the {callsign} callsign";
                    await context.Response.WriteAsync($"RESPONSE: {responseText}");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }


            // switch((callsign ?? "").ToLower())
            // {
            //     case "aal1":
            //         responseText = "Callsign: AAL1";
            //         break;
            //     default:
            //         responseText = "Callsign: INVALID";
            //         break;
            // }

        }


        /* NOTE: All of these require that you first obtain a pilot and then search in Positions */

        public static async Task AltitudeEndpoint(HttpContext context)
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }

        public static async Task GroundspeedEndpoint(HttpContext context)
        {

            string responseText = null;
            string callsign = context.Request.RouteValues["callsign"] as string;


            using(var db = new VatsimDbContext())
            {
                if(callsign != null)
                {
                    Console.WriteLine($"{callsign}");

                    var _groundspeed = await db.Positions.Where(p => p.Callsign == callsign)
                                                         .OrderByDescending(p => p.TimeStamp)
                                                         .ToListAsync();

                    var _pilot_groundspeed = _groundspeed.Where(p => Convert.ToInt32(p.Groundspeed) > 250); 

                    foreach(var p in _pilot_groundspeed)
                    {
                        Console.WriteLine(p.Groundspeed);
                    }

                    // var _departure = await db.Flights.Where(f => f.PlannedDepairport == (flightDeparture ?? "").ToUpper()).ToListAsync();
                    responseText = $"The most recent groundspeed for {callsign} is {_pilot_groundspeed.ElementAt(0).Groundspeed} knots";
                    await context.Response.WriteAsync($"RESPONSE: {responseText}");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }

            //TO DO
            // await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }

        public static async Task LatitudeEndpoint(HttpContext context)        
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }

        public static async Task LongitudeEndpoint(HttpContext context)
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }
    }
}