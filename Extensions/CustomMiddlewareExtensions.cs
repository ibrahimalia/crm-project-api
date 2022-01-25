using Microsoft.AspNetCore.Builder;

namespace Meta.IntroApp.Extensions
{
    public static class CustomMiddlewareExtensions
    {
         public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)  
                {  
                    // Use Middleware TestMiddleWareToWorkAsPolicy  
                    return builder.UseMiddleware<TestMiddleWareToWorkAsPolicy>();  
                }  
    }
}