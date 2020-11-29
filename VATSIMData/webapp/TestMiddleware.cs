using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimData;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp {
    public class TestMiddleware {
        private RequestDelegate nextDelegate;

        public TestMiddleware(RequestDelegate next) {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context, VatsimDbContext db) {
            if (context.Request.Path == "/test") {
                await context.Response.WriteAsync($"There are {db.Pilots.Count()} pilots in the db\n");
                await context.Response.WriteAsync($"There are {db.Flights.Count()} flights in the db\n");
                await context.Response.WriteAsync($"There are {db.Controllers.Count()} controllers in the db\n");
            } else {
                await nextDelegate(context);
            }
        }
    }
}