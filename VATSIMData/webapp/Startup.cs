using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using VatsimLibrary.VatsimDb;
using VATSIMData.Worker;

namespace VATSIMData.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //bring in the vatsim library for the db context
            services.AddDbContext<VatsimLibrary.VatsimDb.VatsimDbContext>();

            //add background worker
            services.AddHostedService<VatsimDataHarvesterWorker>();

            //if we want to use MVC, we simply add in controllers 
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
            //enable Razor Pages support
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //other optimizations
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                //session ids must be stored in client-side cookies
                options.Cookie.IsEssential = true;
            });

            // JSON serializer config
            services.Configure<JsonOptions>(opts => {
                opts.JsonSerializerOptions.IgnoreNullValues = true;
            });

            //CORS
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseMiddleware<TestMiddleware>();

            // using endpoints
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                // since we won't be making endpoints manually, we'll add in 
                // controllers
                // endpoints.MapWebService();
                endpoints.MapControllers();
                // add in default route of home controller
                //endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{cid?}/{callsign?}/{timelogon?}");
                // this is a substitute for the above but doesn't have the additional paths
                endpoints.MapDefaultControllerRoute();
                //razor pages support
                endpoints.MapRazorPages();
            });

            // we skip the database seeding as the client program handles that
        }
    }
}
