using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Meta.IntroApp.Extensions
{
    public static class RouteMiddleWare 
    {
        public static void adminMiddleWare(this IApplicationBuilder app){
            
            app.UseWhen(x => x.Request.Path.StartsWithSegments("/api/V1/Admin/Branch/List"), m =>
                {
                    m.UseWhen(z => z.User.IsInRole("user"), n =>
                        n.Run(async b => b.Response.StatusCode = StatusCodes.Status403Forbidden));
                    m.UseWhen(z =>!z.User.HasClaim(c=> c.Type == ClaimTypes.NameIdentifier),
                        a => a.Run(async y => y.Response.StatusCode = StatusCodes.Status401Unauthorized));
                    //Extenstion method in class CustomMiddleWareExtenstions 
                    m.UseCustomMiddleware();
                }
            );
            
      
        }
    }
}