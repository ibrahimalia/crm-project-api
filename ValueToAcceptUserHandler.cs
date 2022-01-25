using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Meta.IntroApp
{
    public class ValueToAcceptUserHandler:AuthorizationHandler<ValueToAcceptUser>
    {
        private readonly INameUser _nameUser;
        private readonly MetaITechDbContext _metaITechDbContext;

        public ValueToAcceptUserHandler(INameUser nameUser , MetaITechDbContext metaITechDbContext)
        {
            _nameUser = nameUser;
            _metaITechDbContext = metaITechDbContext ;
        }
        protected  override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValueToAcceptUser requirement)
        {
            if (!context.User.HasClaim(c=> c.Type == ClaimTypes.NameIdentifier))
            { 
              return  Task.CompletedTask;
            }

            var id = context.User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier);
            var dataUser = _metaITechDbContext.Accounts.Where(x => x.Id == int.Parse(id.Value) ).ToList();
    
            foreach (var name in dataUser)
            {
               var value = _nameUser.Get(name.FirstName);
               if (value == requirement.Value)
               {
                   context.Succeed(requirement);
               }
                
            }
            return Task.CompletedTask;

        }
    }
}