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
using Microsoft.Extensions.Options;

using Platform.Services;

namespace Platform
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // so, think of these as the Interface seen in code and the implementation that should be injected
            services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

            // despite its name, a service is only called upon when DI is resolved at startup
            services.AddTransient<IResponseFormatter, GuidService>();

            // same object but will change when a new request is made
            services.AddScoped<IResponseFormatter, GuidService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env,
                              IResponseFormatter formatter)
        {

            // in chapter 14, this method is simplified.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<WeatherMiddleware>();

            app.Use(
                async (context, next) =>
                {
                    if(context.Request.Path == "/middleware/function")
                    {
                        //await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
                        // singleton pattern for service use
                        // await TextResponseFormatter.Singleton
                        //                            .Format(context, "Middleware Function: It is snowing in Chicago");

                        //now we use the TypeBroker
                        // await TypeBroker.Formatter.Format(context, "Middleware Function: It is snowing in Chicago");

                        //and now, Dependency Injection
                        // IResponseFormatter formatter = app.ApplicationServices.GetService<IResponseFormatter>();
                        IResponseFormatter formatter = context.RequestServices.GetService<IResponseFormatter>();
                        await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
                    }
                    else
                    {
                        await next();
                    }
                }
            );

            app.UseEndpoints( endpoints =>
                {
                    // endpoints.MapGet("/endpoint/class", WeatherEndpoint.Endpoint);
                    // endpoints.MapWeather("/endpoint/class");
                    endpoints.MapEndpoint<WeatherEndpoint>("/endpoint/class");

                    endpoints.MapGet("/endpoint/function", 
                        async context => 
                        {
                            //await context.Response.WriteAsync("Endpoint Function: It is sunny in LA");
                            // use singleton
                            // await TextResponseFormatter.Singleton.Format(context, "Endpoint Function: It is sunny in LA");

                            //now we use the TypeBroker
                            // await TypeBroker.Formatter.Format(context, "Endpoint Function: It is sunny in LA");
                            // IResponseFormatter formatter = app.ApplicationServices.GetService<IResponseFormatter>();
                            IResponseFormatter formatter = context.RequestServices.GetService<IResponseFormatter>();                            
                            await formatter.Format(context, "Endpoint Function: It is sunny in LA");

                        }
                    );
                }
            );

            app.Use(
                async(context, next) => 
                {
                    await context.Response.WriteAsync("\nTerminal Middleware Reached");
                }
            );            
        }
    }
}
