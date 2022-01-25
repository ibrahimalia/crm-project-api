using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.Services.FeedBack;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class FeedBackController : BaseClientController
    {
        private readonly IClientFeedBackEmail _feedBackEmail;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FeedBackController(IClientFeedBackEmail feedBackEmail, IHttpContextAccessor httpContextAccessor)
        {
            _feedBackEmail = feedBackEmail;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// send feed back, user must be logged in
        /// </summary>
        /// <param name="feedBack"></param>
        /// <returns></returns>
        [HttpPost("Auth")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<BaseAPIResult> sendFeedBack(FeedBackDTO feedBack)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            await _feedBackEmail.SendEmailAsync(clientId1 , feedBack );
            return SuccessResponse("");
        }

        /// <summary>
        /// send feed back,[for anonymous users] 
        /// </summary>
        /// <param name="feedBack"></param>
        /// <returns></returns>
        [HttpPost("NoAuth")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
     
        public async Task<BaseAPIResult> anonymousFeedBack(FeedBackDTO feedBack)
        {
        
            await _feedBackEmail.SendEmailAsync(null, feedBack);
            return SuccessResponse("");
        }





        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetFeedBackDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> getFeedBack()
        {

          var feedBacks = await _feedBackEmail.GetFeedBacks();
            return SuccessResponse(feedBacks);

        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
