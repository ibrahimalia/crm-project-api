using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Services.Request.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class RequestController : BaseClientController
    {
        private readonly IClientRequest _request;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestController(IClientRequest request , IHttpContextAccessor httpContextAccessor)
        {
            _request = request;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// send request [Authorize]
        /// </summary>     
        /// <param name="addRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("Auth")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> sendRequest(AddRequestDTO addRequestDTO)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            await _request.AddRequest(clientId1, addRequestDTO);
            return BaseSuccessResponse();
        }


        /// <summary>
        /// send request [Un-Authorize]
        /// </summary>     
        /// <param name="addRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]        
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> sendRequest2(AddRequestDTO addRequestDTO)
        {
           
            await _request.AddRequest(null, addRequestDTO);
            return BaseSuccessResponse();
        }



        /// <summary>
        /// Get all requests for specific merchant and  specific client
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetRequestListDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjects([FromQuery] PaginationFilterDTO filter)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            var result = await _request.GetRequests(clientId1 , filter);
            return SuccessResponse(result);
        }

        /// <summary>
        /// Get request detailes for specific merchant and  specific client
        /// </summary>
        /// <param name="RequestId"></param>
     
        /// <returns></returns>
        [HttpGet("Details")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetRequestDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetRequestDetails([Required(AllowEmptyStrings = false)] int? RequestId)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            var result = await _request.GetRequestDetailes(clientId1, RequestId);
            return SuccessResponse(result);
        }



      /// <summary>
      /// Update request
      /// </summary>     
      /// <param name="requestID"></param>
      /// <param name="addRequestDTO"></param>
      /// <returns></returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> PutRequest([Required(AllowEmptyStrings = false)] int requestID , AddRequestDTO addRequestDTO)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            await _request.UpdateRequest(clientId1, requestID, addRequestDTO);
            return BaseSuccessResponse();
        }


        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

    }
}
