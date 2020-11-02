using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Platform 
{
    public class Population
    {
        private RequestDelegate next;

        public Population(){}

        public Population(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            //take the incoming path and break it up by directory separators
            string[] parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);

            if(parts.Length == 2 && parts[0] == "population")
            {
                string city = parts[1];
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
            }

            if(next != null)
            {
                await next(context);
            }
        }
    }
}