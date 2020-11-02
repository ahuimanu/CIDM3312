using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Platform 
{
    public class Capitol
    {
        // private RequestDelegate next;

        // public Capitol(){}

        // public Capitol(RequestDelegate nextDelegate)
        // {
        //     next = nextDelegate;
        // }

        public static async Task EndPoint(HttpContext context)
        {
            string capitol = null;
            string country = context.Request.RouteValues["country"] as string;

            switch((country ?? "").ToLower())
            {
                case "uk":
                    capitol = "London";
                    break;

                case "france":
                    capitol = "Paris";
                    break;
                case "monaco":
                    context.Response.Redirect($"/population/{country}");
                    break;
            }

            if(capitol != null)
            {
                await context.Response.WriteAsync($"{capitol} is the capitol of {country}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }            
        }

    //     public async Task Invoke(HttpContext context)
    //     {
    //         //take the incoming path and break it up by directory separators
    //         string[] parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);

    //         if(parts.Length == 2 && parts[0] == "capitol")
    //         {
    //             string country = parts[1];
    //             string capitol = null;
    //             switch(country.ToLower())
    //             {
    //                 case "uk":
    //                     capitol = "London";
    //                     break;

    //                 case "france":
    //                     capitol = "Paris";
    //                     break;
    //                 case "monaco":
    //                     context.Response.Redirect($"/population/{country}");
    //                     break;
    //             }

    //             if(capitol != null)
    //             {
    //                 await context.Response.WriteAsync($"{capitol} is the capitol of {country}");
    //             }
    //         }

    //         if(next != null)
    //         {
    //             await next(context);
    //         }
    //     }
    }
}