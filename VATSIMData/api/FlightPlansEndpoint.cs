using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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
            switch((aircraftType ?? "").ToLower())
            {
                case "a319":
                    responseText = "A319";
                    break;
                default:
                    responseText = "EMPTY";
                    break;
            }

            if(aircraftType != null)
            {
                await context.Response.WriteAsync($"{responseText} was found");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
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