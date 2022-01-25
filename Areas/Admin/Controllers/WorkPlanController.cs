using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.WorkPlan;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class WorkPlanController : BaseAdminController
    {
        private readonly IAdminWorkPlanService _WorkPlan;

        public WorkPlanController(IAdminWorkPlanService WorkPlan)
        {
            _WorkPlan = WorkPlan;
        }

        /// <summary>
        /// get plan detailes
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        public async Task<APIResult<WorkPlanDTO>> Get([Required] int? planId)
        {
            return SuccessResponse(await _WorkPlan.GetWorkPlanDetailes(planId));
        }

        /// <summary>
        /// Get list of plans
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<WorkPlanDTO>>))]
        public async Task<APIResult<List<WorkPlanDTO>>> WorkPlan([Required] int? planId)
        {
            return SuccessResponse(await _WorkPlan.GetAllWorkPlanDetailes());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseAPIResult> AddWorkPlan(AddWorkPlanDTO plan)
        {
            await _WorkPlan.AddWorkPlan(plan);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="newworkPlan"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<BaseAPIResult> UpdatePlan([Required] int? planId, AddWorkPlanDTO newworkPlan)
        {
            await _WorkPlan.UpdateWorkPlan(planId.Value, newworkPlan);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<BaseAPIResult> deletePlan([Required] int? planId)
        {
            await _WorkPlan.DeleteWorkPlan(planId.Value);
            return BaseSuccessResponse();
        }
    }
}