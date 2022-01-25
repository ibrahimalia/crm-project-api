using Meta.IntroApp.APIErrorResults;
using Meta.IntroApp.Attributes;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.JWT;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.AppExceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class AccountController : BaseAdminController
    {
        private readonly UserManager<Account> _userManager;
        private readonly MetaITechDbContext _appDbContext;
        private readonly SignInManager<Account> _signInManager;
        public IConfiguration Configuration { get; set; }

        public AccountController(UserManager<Account> userManager, MetaITechDbContext appDbContext, SignInManager<Account> signInManager, IConfiguration Configuration)
        {
            this._userManager = userManager;
            this._appDbContext = appDbContext;
            this._signInManager = signInManager;
            this.Configuration = Configuration;
        }

        /// <summary>
        /// Create a new Adminmistrator
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateAdmin")]
        public async Task<BaseAPIResult> AddAdmin(UserRegisterInformationDTO model)
        {
            //check if the email is in use
            var anyOldUserWithSameEmail = await _appDbContext.Accounts.AnyAsync(a => a.Email == model.Email && a.MerchantId == CurrentMerchantId);
            if (!anyOldUserWithSameEmail)
            {
                var user = new Account
                {
                    UserName = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    IsActive = true,
                    PhoneNumber = model.PhoneNumber,
                    MerchantId = CurrentMerchantId,
                    AccountType = AccountType.Admin,
                    Image = model.Image == null ? "" : JsonConvert.SerializeObject(model.Image),
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return BaseSuccessResponse();
                }
                throw new ApplicationException(result.Errors.FirstOrDefault().Description);
            }
            else

                throw new ApplicationException(AppExceptions.EmailAlreadyExists);
        }



        /// <summary>
        /// When account not confirmed the error response will contains code 1 with and the data will be an object containing the user ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [IgnoreHeaderMearchantInfo]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<LoginInformationDTO>))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(APIResult<AccountNotConfirmedResponse>))]
        public async Task<BaseAPIResult> Login(LoginInformationDTO model)
        {
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Admin && a.Email == model.Email);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            if (!user.EmailConfirmed)
                return ErrorResponse(1, new AccountNotConfirmedResponse
                {
                    UserId = user.Id
                }, AppExceptions.EmailNotConfirmedYet);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var authToken = JWTGenerator.GenerateJWTToken(new TokenClaimsInfoDTO()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    Role = (List<string>)roles,
                }, Configuration);

                return SuccessResponse(new UserDTO()
                {
                    Id = user.Id,
                    Email = user.Email.ToLower(),
                    Image = JsonConvert.DeserializeObject<string>(user.Image).WrapContentUrl(),
                    Token = authToken
                });
            }
            else
                throw new ApplicationException(AppExceptions.AccountNotfound);
        }



        /// <summary>
        /// Get All Usres
        /// </summary>
      
        /// <returns></returns>
        [HttpPost("GetUsers")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<List<UserInfoDTO>>))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetUsers()
        {
            List<UserInfoDTO> result = new List<UserInfoDTO>();
            var users = _userManager.Users.Where(x => x.MerchantId == CurrentMerchantId);

            foreach (var item in users)
            {
                UserInfoDTO user = new UserInfoDTO
                {
                    Name = item.FirstName + item.LastName,
                    Email = item.Email,
                    Role = item.AccountType == AccountType.Admin ? "admin" : "client",
                    Status = item.IsActive
                };
                result.Add(user);
            }

            return SuccessResponse(result);
        }

    }
}