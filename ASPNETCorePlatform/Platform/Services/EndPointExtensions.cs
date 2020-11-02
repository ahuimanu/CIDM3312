using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Platform.Services;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointExtensions
    {
        public static void MapEndpoint<T>(this IEndpointRouteBuilder app, 
                                          string path,
                                          string methodName = "Endpoint")
        {
            MethodInfo methodInfo = typeof(T).GetMethod(methodName);
            if(methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new System.Exception("Method cannot be used");
            }

            T endpointInstance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

            ParameterInfo[] methodParams = methodInfo.GetParameters();

            //admittedly, this is VERY complex code that uses reflection to provide the flexibility of
            //DI service use.  
            app.MapGet(path, 
                context => {
                    T endpointInstance = ActivatorUtilities.CreateInstance<T>(context.RequestServices);
                    return (Task)methodInfo.Invoke(endpointInstance,
                        methodParams.Select(p => p.ParameterType == typeof(HttpContext) 
                                ? context 
                                : context.RequestServices.GetService(p.ParameterType)).ToArray());
                });
        }
    }
}