using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Platform
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // services.Configure<MessageOptions>( options =>
            //     {
            //         options.CityName = "Albany";
            //     }
            // );            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env)
                              //IOptions<MessageOptions> msgOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region previous middleware examples
            // use the location middleware class
            // app.UseMiddleware<LocationMiddleware>();

            // we pass options along as arguments when the services are configured
            // app.Use(
            //     async(context, next) => 
            //     {
            //         if(context.Request.Path == "/location")
            //         {
            //             MessageOptions opts = msgOptions.Value;
            //             await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
            //         }
            //         else
            //         {
            //             await next();
            //         }
            //     }
            // );

            /*  __short circuit__
                A request/response cycle can be short-circuited
            */
            // app.Use(
            //     async(context, next) => 
            //     {
            //         if(context.Request.Path == "/short")
            //         {
            //             await context.Response.WriteAsync($"Rquest was short-circuited");
            //         }
            //         else
            //         {
            //             await next();
            //         }
            //     }
            // );            

            /*  __custom middleware__
                context - envelops the request
                next - the next stop in the middleware/request chain

                we use a simple lamdba method out of convenience, but it is not very reusbale
            */
            // app.Use(
            //     async(context, next) => {
            //         //we can interrogate the Request object to learn more about what is being asked of the server
            //         if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "yes")
            //         {
            //             await context.Response.WriteAsync("This is my custom middleware\n");
            //         }
            //         await next();
            //     }
            // );

            /*  __class-based custom middleware__
                With a class-based middleware, we have something that is reusable

                The use of Generic typing helps here.

            */
            // app.UseMiddleware<QueryStringMiddleWare>();

            #endregion

            // we can move these to the routing structure as well
            // app.UseMiddleware<Population>();
            // app.UseMiddleware<Capitol>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("routing", async context =>
                {
                    await context.Response.WriteAsync("Request was Routed");
                });

                endpoints.MapGet("capitol/uk", new Capitol().Invoke);
                endpoints.MapGet("population/paris", new Population().Invoke);

            });

            app.Use(
                async(context, next) => 
                {
                    await context.Response.WriteAsync("\nTerminal Middleware Reached");
                }
            );            
        }
    }
}
