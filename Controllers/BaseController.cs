using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.Messages;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Meta.IntroApp.Extensions;

namespace Meta.IntroApp.Controllers
{
    [Route("api/V1/[area]/[controller]")]
    [Area("Common")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private string _currentMerchantId;
        private int? _currentBranchId;
        private long? _userID;
       



        public BaseController()
        {
        }

        protected string CurrentMerchantId
        {
            get
            {
                _currentMerchantId ??= MerchantDetecterHelper.GetCurrentMerchantId(HttpContext);
                return _currentMerchantId;
            }
        }
        protected int? CurrentBranchId
        {
            get
            {
                _currentBranchId ??= MerchantDetecterHelper.GetCurrentBranchId(HttpContext);
                return _currentBranchId;
            }
        }
        protected long? CurrentUserId
        {
            get
            {
                _userID ??= MerchantDetecterHelper.GetCurrentUserId(HttpContext);
                return _userID;
            }
        }



        /// <summary>
        /// Get Service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetService<T>() where T : class
        {
            return HttpContext.RequestServices.GetService<T>();
        }

        public long? CurrentAccountId => User.GetCurrentAccountId();

        public Account _currentAccount { get; set; }

        public Account CurrentAccount
        {
            get
            {
                _currentAccount = _currentAccount ?? GetService<UserManager<Account>>().GetUserAsync(User).GetAwaiter().GetResult();
                return _currentAccount;
            }
        }


        /// <summary>
        /// return error response from model state
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected BaseAPIResult ErrorResponseFromModelState()
        {
            return new BaseAPIResult
            {
                IsSuccess = false,
                Message = ModelState.Values.FirstOrDefault(v => v.Errors.Any())?.Errors?.FirstOrDefault()?.ErrorMessage ?? AppExceptions.UnExpectedError
            };
        }

        protected BaseAPIResult BaseSuccessResponse(string message = null)
        {
            return new BaseAPIResult
            {
                IsSuccess = true,
                Message = message ?? Messages.TaskCompletedSuccessfully
            };
        }

        protected BaseAPIResult ErrorResponse(string message = null)
        {
            return new BaseAPIResult
            {
                IsSuccess = false,
                Message = message ?? AppExceptions.UnExpectedError
            };
        }



        protected BaseAPIResult ErrorResponse(int code, string message = null)
        {
            return new APIResult<object>
            {
                IsSuccess = false,
                Code = code,
                Message = message ?? AppExceptions.UnExpectedError
            };
        }

        protected BaseAPIResult ErrorResponse<T>(int code, T data, string message = null)
        {
            return new APIResult<T>
            {
                IsSuccess = false,
                Code = code,
                Data = data,
                Message = message ?? AppExceptions.UnExpectedError
            };
        }


        protected APIResult<T> SuccessResponse<T>(T data, string message = null)
        {
            return new APIResult<T>
            {
                IsSuccess = true,
                Message = message ?? Messages.TaskCompletedSuccessfully,
                Data = data
            };
        }
    }
}