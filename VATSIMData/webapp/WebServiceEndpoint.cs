
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace Microsoft.AspNetCore.Builder {

    public static class WebServiceEndpoint {
        private static string BASEURL = "api/pilots";

        public static void MapWebService(this IEndpointRouteBuilder app) {

            app.MapGet($"{BASEURL}/{{cid}}", async context => {
                long key = long.Parse(context.Request.RouteValues["cid"] as string);
                VatsimDbContext db = context.RequestServices.GetService<VatsimDbContext>();
                VatsimClientPilotV1 pilot = db.Pilots.Find(key);
                if (pilot == null) {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                } else {
                    context.Response.ContentType = "application/json";
                    await context.Response
                        .WriteAsync(JsonSerializer.Serialize<VatsimClientPilotV1>(pilot));
                }
            });

            /* honestly, we could stop here because we are getting data from the database, returned as JSON
               through this endpoint.  The MVC stuff is to demonstrate how the REST Web API handles this stuff
               "built in"
            */
            app.MapGet(BASEURL, async context => {
                VatsimDbContext data = context.RequestServices.GetService<VatsimDbContext>();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer
                    .Serialize<IEnumerable<VatsimClientPilotV1>>(data.Pilots));
            });

            // skipping write operations
            // app.MapPost(BASEURL, async context => {
            //     DataContext data = context.RequestServices.GetService<DataContext>();
            //     Product p = await
            //         JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
            //     await data.AddAsync(p);
            //     await data.SaveChangesAsync();
            //     context.Response.StatusCode = StatusCodes.Status200OK;
            // });
        }
    }
}