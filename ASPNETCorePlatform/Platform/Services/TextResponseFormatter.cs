using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Platform.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        private static TextResponseFormatter shared;

        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Response: {++responseCounter}:\n{content}");
        }

        // trying the Singleton pattern
        public static TextResponseFormatter Singleton 
        {
            get 
            {
                if(shared == null)
                {
                    shared = new TextResponseFormatter();
                }
                
                return shared;
            }
        }
    }
}