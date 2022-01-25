using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_Tasks;
using Meta.IntroApp.Services.PRJ_Task.admin;
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
    public class PRJTaskController : BaseAdminController
    {
        private readonly IAdminTask _task;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJTaskController(IAdminTask task, IHttpContextAccessor httpContextAccessor)
        {
            _task = task;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get list of tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTaskDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListTasks([Required(AllowEmptyStrings = false)] int projectId,[FromQuery] PRJTaskFilter TaskFilter)
        {
            var tags = await _task.GetTasks(projectId , TaskFilter);
            return SuccessResponse(tags); ;
        }


        /// <summary>
        /// Get list of required DropDowns Data
        /// </summary>
        /// <returns></returns>
        [HttpGet("TaskDropDownsData")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<TaskDropDownsDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TaskDropDownsData()
        {
            var data = await _task.GetTaskDropDownsData();
            return SuccessResponse(data); ;
        }

        /// <summary>
        /// Get detailes of task
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetTaskDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Taskdetailes([Required(AllowEmptyStrings = false)] int id)
        {
            var tags = await _task.GetTaskDetailes(id);
            return SuccessResponse(tags); ;
        }


        /// <summary>
        /// Add New task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Task")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Tasks(AddTaskDTO task)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _task.AddTask(adminId1, task);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update task data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Task/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateTask([Required(AllowEmptyStrings = false)] int id, AddTaskDTO task)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _task.UpdateTask(adminId1,id ,task);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteTask([Required(AllowEmptyStrings = false)] int id)
        {
            await _task.ArchiveTask(id);
            return BaseSuccessResponse();
        }
        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
