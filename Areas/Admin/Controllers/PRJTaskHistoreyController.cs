using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using Meta.IntroApp.Services.PRJ_TaskHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJTaskHistoreyController : BaseAdminController
    {
        private readonly IAdminTaskHistory _taskHistory;

        public PRJTaskHistoreyController(IAdminTaskHistory taskHistory)
        {
            _taskHistory = taskHistory;
        }



        /// <summary>
        /// Get list of task logs
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<TaskHistoryDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> List( [Required(AllowEmptyStrings =false)] int taskId)
        {
            var result = await _taskHistory.GetTaskLogs(taskId);
            return SuccessResponse(result); ;
        }
    }
}