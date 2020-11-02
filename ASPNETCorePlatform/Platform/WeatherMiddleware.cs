using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Platform.Services;

namespace Platform
{
    public class WeatherMiddleware 
    {
        private RequestDelegate next;
        // make it clear that we will depend on a formatter
        // private IResponseFormatter formatter;

        public WeatherMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;

            // the formatter we'll use is passed in at the time of use
            // hend the "injection" in DI.
            // formatter = respFormatter;
        }

        /// <summary>
        /// Recieves a DI response formatter on a "per call" basis
        /// </summary>
        /// <param name="context">HTTP context for Request and Response</param>
        /// <param name="formatter">DI'd implementation of IResponseFormatter</param>
        /// <returns>Task for async</returns>
        public async Task Invoke(HttpContext context, 
                                 IResponseFormatter formatter1,
                                 IResponseFormatter formatter2,
                                 IResponseFormatter formatter3)
        {
            if(context.Request.Path == "/middleware/class")
            {
                // await context.Response.WriteAsync("Middleware Class: it is raining in London");
                // await formatter.Format(context, "Middleware Class: it is raining in London");
                await formatter1.Format(context, string.Empty);
                await formatter2.Format(context, string.Empty);
                await formatter3.Format(context, string.Empty);
            }
            else
            {
                await next(context);
            }
        }
    }
}