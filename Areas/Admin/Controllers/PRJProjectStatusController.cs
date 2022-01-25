﻿using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_ProjectStatusDTO;
using Meta.IntroApp.Services;
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
    public class PRJProjectStatusController : BaseAdminController
    {
        private readonly IAdminProjectStatus _State;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJProjectStatusController(IAdminProjectStatus State, IHttpContextAccessor httpContextAccessor)
        {
            _State = State;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of Project Status
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetProjectStatusDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjectStatus()
        {
            var result = await _State.GetProjectStatus();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New Project Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ProjectStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ProjectStatus(AddProjectStatusDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _State.AddProjectStatus(adminId1 , model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update Project Status value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ProjectStatus/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateProjectStatus([Required(AllowEmptyStrings = false)] int id, AddProjectStatusDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _State.UpdateProjectStatus(adminId1, id, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific Project Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteProjectStatus([Required(AllowEmptyStrings = false)] int id)
        {
            await _State.DeleteProjectStatus(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
