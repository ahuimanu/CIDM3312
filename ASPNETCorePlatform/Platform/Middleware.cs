using Microsoft.AspNetCore.Http;
using  System.Threading.Tasks;

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
}