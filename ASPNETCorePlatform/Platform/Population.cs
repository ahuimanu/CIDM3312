using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Platform 
{
    public class Population
    {

        public static async Task Endpoint(HttpContext context)
        {
            // The ?? is the null coalescing operator: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            string city = context.Request.RouteValues["city"] as string ?? "london";

            int? population = null;

            switch(city.ToLower())
            {
                case "london":
                    population = 8_136_000;
                    break;

                case "paris":
                    population = 2_141_000;
                    break;
                case "monaco":
                    population = 39_000;
                    break;
            }

            if(population.HasValue)
            {
                await context.Response.WriteAsync($"City: {city}, Population: {population}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}