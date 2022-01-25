using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_TaskStatusDTO;
using Meta.IntroApp.Services.PRJ_TaskStatus;
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
    public class PRJTaskStatusController : BaseAdminController
    {
        private readonly IAdminTaskStatus _State;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJTaskStatusController(IAdminTaskStatus State, IHttpContextAccessor httpContextAccessor)
        {
            _State = State;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of task Status
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTaskStatusDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListTaskStatus()
        {
            var result = await _State.GetTaskStatus();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New task Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TaskStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TaskStatus(AddTaskStatusDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _State.AddTaskStatus(adminId1, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update task Status value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("TaskStatus/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateTaskStatus([Required(AllowEmptyStrings = false)] int id, AddTaskStatusDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _State.UpdateTaskStatus(adminId1 , id ,model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific task Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteTaskStatus([Required(AllowEmptyStrings = false)] int id)
        {
            await _State.DeleteTaskStatus(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}

