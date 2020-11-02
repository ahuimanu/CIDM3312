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

        public static async Task AltitudeEndpoint(HttpContext context)
        {
            string answer = null;
            string dude = context.Request.RouteValues["dude"] as string;
            switch((dude ?? "").ToLower())
            {
                case "jeff":
                    answer = "Pilot: jeff";
                    break;
                default:
                    answer = "Pilot: dude";
                    break;
            }

            if(dude != null)
            {
                await context.Response.WriteAsync($"{answer} looks like a lady");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }


        public static async Task GroundspeedEndpoint(HttpContext context)
        {
            string answer = null;
            string dude = context.Request.RouteValues["dude"] as string;
            switch((dude ?? "").ToLower())
            {
                case "jeff":
                    answer = "Pilot: jeff";
                    break;
                default:
                    answer = "Pilot: dude";
                    break;
            }

            if(dude != null)
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