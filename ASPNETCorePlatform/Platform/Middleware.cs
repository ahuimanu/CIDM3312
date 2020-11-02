using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Platform
{
    public class QueryStringMiddleWare 
    {
        private RequestDelegate next;

        //constructor
        public QueryStringMiddleWare(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "yes")
            {
                await context.Response.WriteAsync("This is my class-based custom middleware\n");
            }
            await next(context);
        }
    }

    public class LocationMiddleware
    {
        private RequestDelegate next;
        private MessageOptions options;

        public LocationMiddleware(RequestDelegate nextDelegate,
                                  IOptions<MessageOptions> opts)
        {
            next = nextDelegate;
            options = opts.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
            }
            else
            {
                await next(context);
            }
        }
    }
}