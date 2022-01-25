using Meta.IntroApp.APIErrorResults;
using Meta.IntroApp.APIModels;
using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.Areas.Client.DTOs;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.JWT;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Localizations.Tokens;
using Meta.IntroApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class AccountController : BaseClientController
    {
        private readonly UserManager<Account> _userManager;
        private readonly MetaITechDbContext _appDbContext;
        private readonly SignInManager<Account> _signInManager;

        public const int ConfirmationCodeValidHours = 6;

        public IConfiguration Configuration { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(UserManager<Account> userManager, MetaITechDbContext appDbContext, SignInManager<Account> signInManager, IConfiguration Configuration
                                 , IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;
            this._appDbContext = appDbContext;
            this._signInManager = signInManager;
            this.Configuration = Configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Register on the application
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ///
      
        [HttpPost("Register")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<RegisterUserResultDTO>))]
        [ProducesResponseType(500, StatusCode = 200, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Register(RegisterClientDTO model)
        {
            //check if the email is in use
            var anyOldUserWithSameEmail = await _appDbContext.Accounts.AnyAsync(a => a.Email == model.Email && a.MerchantId == CurrentMerchantId && a.AccountType == AccountType.Client);
            if (!anyOldUserWithSameEmail)
            {
                var user = new Account
                {
                    UserName = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsActive = true,
                    Email = model.Email?.Trim()?.ToLower(),
                    EmailConfirmed = false,
                    ConfirmationCode = GenerateConformationCode(),
                    ConfirmationCodeEndDate = DateTime.Now.AddHours(ConfirmationCodeValidHours),
                    MerchantId = CurrentMerchantId,
                    AccountType = AccountType.Client,
                    PhoneNumber = model.PhoneNumber,
                    Image = model.Image == null ? "" : JsonConvert.SerializeObject(model.Image),
                    
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    //ToDo: Email to be sent
                    var message = string.Format(Messages.YourAccountConfirmationCode, user.ConfirmationCode);
                    GetService<IEmailService>().SendAsync(Tokens.ConfirmAccount, message, message, new EmailReceiver(user.Email, user.GetName()));

                    return SuccessResponse(new RegisterUserResultDTO
                    {
                        UserId = await _appDbContext.Accounts.Where(a => a.Email == model.Email && a.MerchantId == CurrentMerchantId && a.AccountType == AccountType.Client)
                                            .Select(c => c.Id).FirstOrDefaultAsync()
                    });
                }
                throw new ApplicationException(result.Errors.FirstOrDefault().Description);
            }
            else

                throw new ApplicationException(AppExceptions.EmailAlreadyExists);
        }

        [HttpPost("GetUserCode")]
        public APIResult<string> GetUserCode(int id)
        {
            return SuccessResponse(_appDbContext.Accounts.FirstOrDefault(c => c.Id == id)?.ConfirmationCode);
        }

        /// <summary>
        /// This is for Clients only
        /// When account not confirmed the error response will contains code 1 with and the data will be an object containing the user ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<UserDTO>))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(APIResult<AccountNotConfirmedResponse>))]
        public async Task<BaseAPIResult> Login(LoginInformationDTO model)
        {
            model.Email = model.Email?.Trim()?.ToLower();
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Client && a.Email == model.Email && a.MerchantId == CurrentMerchantId);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            if (!user.EmailConfirmed)
            {
                await ResendCode(user.Id);
                return ErrorResponse(1, new AccountNotConfirmedResponse
                {
                    UserId = user.Id
                }, AppExceptions.EmailNotConfirmedYet);

            }
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
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email.ToLower(),
                    Token = authToken,
                    Image = JsonConvert.DeserializeObject<string>(user.Image).WrapContentUrl(),
                    PhoneNumber = user.PhoneNumber
                    
                });
            }
            else
                throw new ApplicationException(AppExceptions.AccountNotfound);
        }



        /// <summary>
        /// Change the user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("ChangePassword")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(CurrentAccount, model.OldPassword);
                if (checkPasswordResult)
                {
                    string resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(CurrentAccount);
                    var resetPasswordResult = await _userManager.ResetPasswordAsync(CurrentAccount, resetPasswordToken, model.NewPassword);
                    if (resetPasswordResult.Succeeded)
                        return BaseSuccessResponse(Tokens.PasswordResetSuccessfully);
                    else
                        throw new ApplicationException(AppExceptions.UnExpectedError);
                }
                throw new ApplicationException(AppExceptions.InvalidPassword);
            }
            else
            {
                return ErrorResponseFromModelState();
            }
        }



        /// <summary>
        /// Confirm the user Account
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost("ConfirmAccount")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<UserDTO>))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ConfirmEmail([Required] long? userId, [Required(AllowEmptyStrings = false)] string code)
        {
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Client && a.Id == userId && a.MerchantId == CurrentMerchantId);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            if (!user.EmailConfirmed)
            {
                if (user.ConfirmationCode != code)
                    throw new ApplicationException(AppExceptions.ConfirmationCodeIsNotValid);
                if (DateTime.Now >= user.ConfirmationCodeEndDate)
                {
                    ////ToDo: Send a new confirmation code
                    //user.ConfirmationCode = GenerateConformationCode();
                    //user.EmailConfirmed = false;
                    //user.ConfirmationCodeEndDate = DateTime.Now.AddHours(ConfirmationCodeValidHours);

                    //send the code
                    //var message = string.Format(Messages.YourAccountConfirmationCode, user.ConfirmationCode);
                    //GetService<IEmailService>().SendAsync(Tokens.ConfirmAccount, message, message, new EmailReceiver(user.Email, user.GetName()));

                    throw new ApplicationException(AppExceptions.ConfirmationExpired);
                }
                user.EmailConfirmed = true;
                user.IsCodeConfirmed = true;
                _appDbContext.Update(user);
                await _appDbContext.SaveChangesAsync();
                var roles = await _userManager.GetRolesAsync(user);
                return SuccessResponse(new UserDTO
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    
                    Token = JWTGenerator.GenerateJWTToken(new TokenClaimsInfoDTO()
                    {
                        Email = user.Email,
                        UserId = user.Id, 
                        Role = (List<string>)roles,
                    }, Configuration)

                });
            }

            throw new ApplicationException(AppExceptions.CodeConfirmedPreviously);
        }

        /// <summary>
        /// Resend the confirmation code
        /// The user id is required when u have it otherwise you should be authorized to access the endpoint
        /// For example in case reset password we need it because you are not authorized
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("ResendCode")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ResendCode(long? userId)
        {
            userId ??= CurrentAccountId;
            if (userId == null)
                throw new ApplicationException("User ID is required!");//should not happen

            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Client && a.Id == userId);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            if (DateTime.Now >= user.ConfirmationCodeEndDate)
            {
                user.ConfirmationCode = GenerateConformationCode();
                user.IsCodeConfirmed = false;
                user.ConfirmationCodeEndDate = DateTime.Now.AddHours(ConfirmationCodeValidHours);
                _appDbContext.Update(user);
                await _appDbContext.SaveChangesAsync();
            }

            //ToDo: Send a new confirmation code
            var message = string.Format(Messages.YourActivationCodeIs, user.ConfirmationCode);
            await GetService<IEmailService>().SendAsync(Tokens.ConfirmAccount, message, message, new EmailReceiver(user.Email, user.GetName()));

            return BaseSuccessResponse();
        }


        /// <summary>
        /// Check if the account code is correct or not
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("CheckCode")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(APIResult<bool>))]
        public virtual async Task<BaseAPIResult> CheckCode([Required] string email, [Required(AllowEmptyStrings = false)] string code)
        {
            return await CommonCheckCode(email, code, AccountType.Client);
        }

        /// <summary>
        /// Reset the password,after reset complete user will receive a code on his email to be entered on confirmForgetPassword endpoint
        /// </summary>
        /// <param name="email">The user email</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ForgetPassword")]
        public virtual async Task<BaseAPIResult> ForgetPassword([FromQuery][Required(AllowEmptyStrings = false)] string email)
        {
            return await CommonForgetPassword(email, AccountType.Client);
        }


        /// <summary>
        /// Confirm  account forget password code
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ConfirmForgetPassword")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<UserDTO>))]
        public virtual Task<BaseAPIResult> ConfirmForgetPassword([FromBody] ResetPasswordAPIModel model)
        {
            return CommonConfirmForgetPassword(model, AccountType.Client);
        }


        /// <summary>
        /// Get Account information
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAccount")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<EditClientDTO>))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public virtual async Task<BaseAPIResult> GetAccount()
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            //fetch the user
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Client && a.MerchantId == CurrentMerchantId
                                                                        && a.Id == clientId1);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            //Get user information
            EditClientDTO client = new EditClientDTO();
            client.FirstName = user.FirstName ;
            client.LastName =user.LastName;
            client.PhoneNumber = user.PhoneNumber ;
            client.Email = user.Email ;
            client.Image = JsonConvert.DeserializeObject<string>(user.Image).WrapContentUrl();


            return SuccessResponse(client);


        }


        /// <summary>
        /// Edit Account information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("EditAccount")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(BaseAPIResult))]
        public virtual async Task<BaseAPIResult> EditAccount(EditClientDTO model) 
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            //fetch the user
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == AccountType.Client && a.MerchantId == CurrentMerchantId
                                                                        && a.Id == clientId1);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            //update user information
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.Image = JsonConvert.SerializeObject(model.Image) ;


            return SuccessResponse(await _userManager.UpdateAsync(user));

     
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        #region Protected and private methods

        protected async Task<BaseAPIResult> CommonConfirmForgetPassword(ResetPasswordAPIModel model, AccountType userType)
        {
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.Email == model.Email && a.AccountType == userType);
            if (user != null)
            {
                if (user.ConfirmationCode != model.Code)
                    throw new ApplicationException(AppExceptions.ConfirmationCodeIsNotValid);
                else if (user.IsCodeConfirmed)
                    throw new ApplicationException(AppExceptions.CodeConfirmedPreviously);
                else if (DateTime.UtcNow >= user.ConfirmationCodeEndDate)
                    throw new ApplicationException(AppExceptions.ConfirmationExpired);
                else if (user.ConfirmationCode == model.Code && !user.IsCodeConfirmed)
                {
                    user.IsCodeConfirmed = true;
                    user.EmailConfirmed = true;
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                    _appDbContext.Update(user);
                    await _appDbContext.SaveChangesAsync();
                    return SuccessResponse(new UserDTO
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Id = user.Id,
                        Token = JWTGenerator.GenerateJWTToken(new TokenClaimsInfoDTO()
                        {
                            Email = user.Email,
                            UserId = user.Id,
                        }, Configuration)

                    });
                }
                else
                    throw new ApplicationException(AppExceptions.ConfirmationCodeIsNotValid);
            }
            else
                throw new ApplicationException(AppExceptions.AccountNotfound);
        }


        protected async Task<BaseAPIResult> CommonForgetPassword(string email, AccountType userType)
        {
            email = email?.Trim().ToLower();
            var user = await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountType == userType && a.Email == email && a.MerchantId == CurrentMerchantId);
            if (user == null)
                throw new ApplicationException(AppExceptions.AccountNotfound);
            user.ConfirmationCode = GenerateConformationCode();
            user.IsCodeConfirmed = false;
            user.ConfirmationCodeEndDate = DateTime.UtcNow.AddHours(ConfirmationCodeValidHours);
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();


            //sending confirmation code in email
            var message = string.Format(Messages.YourAccountConfirmationCode, user.ConfirmationCode);
            GetService<IEmailService>().SendAsync(Tokens.ForgetPassword, message, message, new EmailReceiver(user.Email, user.GetName()));


            return BaseSuccessResponse();
        }

        protected async Task<BaseAPIResult> CommonCheckCode(string email, string code, AccountType userType)
        {
            email = email?.Trim();
            var account = await _appDbContext.Accounts.FirstOrDefaultAsync(c => c.IsActive && c.Email == email && c.AccountType == userType);
            if (account != null)
            {
                if (account.ConfirmationCode != code || account.ConfirmationCodeEndDate >= DateTime.UtcNow)
                    return SuccessResponse(data: false);
                else
                    return SuccessResponse(data: true);
            }
            else
                throw new ApplicationException(AppExceptions.AccountNotfound);
        }

        private string GenerateConformationCode()
        {
            return RandomNumberGenerator.GetInt32(10 * 1000, 100 * 1000 - 1).ToString();
        } 
        #endregion

    }
}