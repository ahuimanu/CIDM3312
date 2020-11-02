using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using api.Services;

namespace api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("VATSIM Data API");
                });

                //using an endpoint to do the work
                endpoints.MapGet("pilots/{callsign}", PilotsEndpoint.CallsignEndpoint);

                endpoints.MapGet("flights/{type}", FlightPlansEndpoint.AircraftTypeEndpoint);

            });

            // end of the line
            app.Use(
                async (context, next) => 
                { 
                    await context.Response.WriteAsync("Terminal Middleware Reached");
                }
            );
        }
    }
}
