using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace api
{
    public class FlightPlansEndpoint
    {

        public static async Task AircraftTypeEndpoint(HttpContext context)
        {
            string responseText = null;
            string aircraftType = context.Request.RouteValues["type"] as string;

            using(var db = new VatsimDbContext())
            {
                if(aircraftType != null)
                {
                    Console.WriteLine($"{aircraftType}");
                   
                    var _aircraft = await db.Flights.Where(f => f.PlannedAircraft.Contains((aircraftType ?? "").ToUpper())).ToListAsync();
                    responseText = $"It is likely that there are least {_aircraft.Count()} {aircraftType}s in the data";
                    await context.Response.WriteAsync($"RESPONSE: {responseText}");
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
            }            
        }

        public static async Task OriginAirportEndpoint(HttpContext context)
        {
            string answer = null;
            string flight = context.Request.RouteValues["flightplans"] as string;
            switch((flight ?? "").ToLower())
            {
                case "flight":
                    answer = "Cool";
                    break;
            }

            if(flight != null)
            {
                await context.Response.WriteAsync($"{answer} looks like a lady");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }

        public static async Task DestinationAirportEndpoint(HttpContext context)
        {
            string answer = null;
            string flight = context.Request.RouteValues["flightplans"] as string;
            switch((flight ?? "").ToLower())
            {
                case "flight":
                    answer = "Cool";
                    break;
            }

            if(flight != null)
            {
                await context.Response.WriteAsync($"{answer} looks like a lady");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }

    }
}