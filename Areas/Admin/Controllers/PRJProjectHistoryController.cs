using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJProjectHistoryController : BaseAdminController
    {
        private readonly IAdminProjectHistory _projectHistory;

        public PRJProjectHistoryController(IAdminProjectHistory projectHistory)
        {
            _projectHistory = projectHistory;
        }



        /// <summary>
        /// Get list of project logs
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<ProjectHistoryDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> List([Required(AllowEmptyStrings = false)] int projectID)
        {
            var result = await _projectHistory.GetProjectLogs( projectID);
            return SuccessResponse(result); ;
        }
    }
}
