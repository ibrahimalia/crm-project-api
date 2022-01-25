using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_Contacts;
using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using Meta.IntroApp.Services.PRJ_Attachement.client;
using Meta.IntroApp.Services.PRJ_Contacts.admin;
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

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJProjectFollowerController : BaseAdminController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IAdminProjectFollower _projectFollower { get; }
        private readonly PRJIAdminContact _contact;

        public PRJProjectFollowerController(IHttpContextAccessor httpContextAccessor, PRJIAdminContact contact, IAdminProjectFollower projectFollower)
        {
            _httpContextAccessor = httpContextAccessor;
            _projectFollower = projectFollower;
            _contact = contact;
        }


        /// <summary>
        /// Get list of Project Followers
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetProjectFollowerDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjectFollower([Required(AllowEmptyStrings =false)]int projectID)
        {
            var tags = await _projectFollower.GetProjectFollower(projectID);
            return SuccessResponse(tags); ;
        }

        /// <summary>
        /// Get list of required Dropdowns data
        /// </summary>
        /// <returns></returns>
        [HttpGet("ProjectFollowerDropdownsData")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<DropdownsDataForAddcontactToProject>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Dropdownsdata()
        {
            var projects = await _contact.GetDropdownsDataForAddcontactToProject();
            return SuccessResponse(projects); ;
        }

        /// <summary>
        /// Add New Project Follower
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ProjectFollower")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ProjectFollowerss(ADDProjectFollowerDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _projectFollower.AddProjectFollower(adminId1 , model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update Project Follower data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ProjectFollower/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateProjectFollower([Required(AllowEmptyStrings = false)] int id, ADDProjectFollowerDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _projectFollower.UpdateProjectFollower(adminId1, id, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific  Project Follower 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteProjectFollower([Required(AllowEmptyStrings = false)] int id)
        {
            await _projectFollower.ArchiveProjectFollower(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
