using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using Meta.IntroApp.Services.PRJ_TaskFollower;
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

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJTaskFollowerController : BaseAdminController
    {
        private readonly IAdminTaskFollowers _taskFollower;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJTaskFollowerController(IAdminTaskFollowers taskFollower, IHttpContextAccessor httpContextAccessor)
        {
            _taskFollower = taskFollower;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get list of task Followers 
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTaskFollowersDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListTaskFollowers([Required(AllowEmptyStrings = false)] int taskID)
        {
            var tags = await _taskFollower.GetTaskFollowers(taskID);
            return SuccessResponse(tags); ;
        }


        /// <summary>
        /// Get detailes of task follower detailes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetTaskFollowersDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TaskFollowerdetailes([Required(AllowEmptyStrings = false)] int id)
        {
            var tags = await _taskFollower.GetTaskFollowerDetailes(id);
            return SuccessResponse(tags); ;
        }


        /// <summary>
        /// Add New task follower
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TaskFollower")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TaskFollower(AddTaskFollowersDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _taskFollower.AddTaskFollower(adminId1, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update task follower data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("TaskFollower/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateTaskFollower([Required(AllowEmptyStrings = false)] int id, AddTaskFollowersDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _taskFollower.UpdateTaskFollower(adminId1, id, model);;
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific task foolower
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteTaskFollower([Required(AllowEmptyStrings = false)] int id)
        {
            await _taskFollower.ArchiveTaskFollower(id);
            return BaseSuccessResponse();
        }
        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
