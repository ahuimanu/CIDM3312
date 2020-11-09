using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace api
{
    public class PilotsEndpoint
    {
        public static async Task CallsignEndpoint(HttpContext context)
        {
            string responseText = null;
            string callsign = context.Request.RouteValues["callsign"] as string;
            switch((callsign ?? "").ToLower())
            {
                case "aal1":
                    responseText = "Callsign: AAL1";
                    break;
                default:
                    responseText = "Callsign: INVALID";
                    break;
            }

            if(callsign != null)
            {
                await context.Response.WriteAsync($"{responseText} is the callsign");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }


        /* NOTE: All of these require that you first obtain a pilot and then search in Positions */

        public static async Task AltitudeEndpoint(HttpContext context)
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
        }

        public static async Task GroundspeedEndpoint(HttpContext context)
        {
            //TO DO
            await context.Response.WriteAsync($"PLEASE IMPLEMENT ME");
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