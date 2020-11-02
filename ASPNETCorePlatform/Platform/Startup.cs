using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Platform
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*  __custom middleware__
                context - envelops the request
                next - the next stop in the middleware/request chain

                we use a simple lamdba method out of convenience, but it is not very reusbale
            */
            app.Use(
                async(context, next) => {
                    //we can interrogate the Request object to learn more about what is being asked of the server
                    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "yes")
                    {
                        await context.Response.WriteAsync("This is my custom middleware\n");
                    }
                    await next();
                }
            );

            /*  __class-based custom middleware__
                With a class-based middleware, we have something that is reusable

                The use of Generic typing helps here.

            */
            app.UseMiddleware<QueryStringMiddleWare>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
