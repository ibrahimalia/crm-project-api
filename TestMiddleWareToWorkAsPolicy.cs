using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Meta.IntroApp
{
    public class TestMiddleWareToWorkAsPolicy : IMiddleware
    {
        private readonly MetaITechDbContext _metaITechDbContext;
        private readonly INameUser _nameUser;
    

        public TestMiddleWareToWorkAsPolicy(MetaITechDbContext metaITechDbContext,INameUser nameUser)
        {
            _metaITechDbContext = metaITechDbContext;
            _nameUser = nameUser;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
        
                
                var id = context.User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier) ;
                var dataUser = _metaITechDbContext.Accounts.Where(x => x.Id == int.Parse(id.Value)).ToList();
                foreach (var name in dataUser)
                {
                    var value = _nameUser.Get(name.FirstName);
                    if (value != 1)
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                 
                    }
                    else
                    {
                        await next(context);
                    }




                } 
            

        }
    }
  
}