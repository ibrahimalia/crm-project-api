using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class UserInfoNameOnlyController : BaseClientController 
    {
     /*   private readonly UserManager<Account> _userManager;
        private readonly MetaITechDbContext _appDbContext;
        private readonly SignInManager<Account> _signInManager;

        public const int ConfirmationCodeValidHours = 6;

        public IConfiguration Configuration { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfoNameOnlyController(UserManager<Account> userManager, MetaITechDbContext appDbContext, SignInManager<Account> signInManager, IConfiguration Configuration
            , IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;
            this._appDbContext = appDbContext;
            this._signInManager = signInManager;
            this.Configuration = Configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// information user name and image only
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpGet("userInfo")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<RegisterUserResultDTO>))]
        [ProducesResponseType(500, StatusCode = 200, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetInfoUser()
        {
            List<UserInfoNameImageOnlyDTO> result = new List<UserInfoNameImageOnlyDTO>();
            
            foreach (var item in users)
            {
                 UserInfoNameImageOnlyDTO user = new UserInfoNameImageOnlyDTO 
                {
                    Name = item.FirstName +""+item.LastName,
                    Image  = JsonConvert.DeserializeObject<string>(item.Image).WrapContentUrl(), 
                };
                result.Add(user);
            }

            return SuccessResponse(result);


            
        }*/
    }
}