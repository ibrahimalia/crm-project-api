using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_jobPosition;
using Meta.IntroApp.Services.PRJ_JobPosition.admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJJobPositionController : BaseAdminController
    {
        private readonly IAdminJobPosition _position;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJJobPositionController(IAdminJobPosition position, IHttpContextAccessor httpContextAccessor)
        {
            _position = position;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of jop positions
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetJobPositions>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListPositions()
        {
            var result = await _position.GetJobPositions();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New Job position
        /// </summary>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("jobPosition")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Positions(AddJobPositionDTO jobPosition)
        {
            
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _position.AddJobPosition(adminId1, jobPosition);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update job position value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobPosition"></param>
      
        /// <returns></returns>
        [HttpPut]
        [Route("jobPosition/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateJobPosition([Required(AllowEmptyStrings = false)] int id, AddJobPositionDTO jobPosition)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _position.UpdateJobPosition(adminId1, id, jobPosition);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteJobPosition([Required(AllowEmptyStrings = false)] int id)
        {
            await _position.DeleteJobPosition(id);
            return BaseSuccessResponse();
        }
        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
