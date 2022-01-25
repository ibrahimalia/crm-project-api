using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_Projects;
using Meta.IntroApp.Services;
using Meta.IntroApp.Services.PRJ_Project.admin;
using Meta.IntroApp.Services.PRJ_ProjectCategory.admin;
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
    public class PRJPojectManagementController : BaseAdminController
    {
        private readonly IAdminProject _project;
        public IHttpContextAccessor _httpContextAccessor { get; }
        private readonly IAdminProjectCategory _category;
        private readonly IAdminProjectStatus _status;

        public PRJPojectManagementController(IAdminProject project,
            IHttpContextAccessor httpContextAccessor,
             IAdminProjectCategory category,
             IAdminProjectStatus status)
        {
            _project = project;
            _httpContextAccessor = httpContextAccessor;
            _category = category;
            _status = status;
        }

        /// <summary>
        /// Get list of Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetProjectDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjects([FromQuery] PRJProjectFilter projectFilter)
        {
            var projects = await _project.GetProjects(projectFilter);
            return SuccessResponse(projects); ;
        }


        /// <summary>
        /// Get list of Projects as tree view
        /// </summary>
        /// <returns></returns>
        [HttpGet("TreeOfProjects")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTreeViewOfProjectsDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TreeOfProjects([FromQuery] PRJProjectFilter projectFilter)
        {
             var projects = await _project.GetTreeViewOfProjects(projectFilter);
            return SuccessResponse(projects); ;
        }



        /// <summary>
        /// Get list of required Dropdowns data
        /// </summary>
        /// <returns></returns>
        [HttpGet("Dropdownsdata")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<AddProjectDropDownData>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Dropdownsdata()
        {
            var projects = await _project.GetProjectDropDownsData();
            return SuccessResponse(projects); ;
        }


        /// <summary>
        /// Get detailes of Project
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetProjectDetailesInfo>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Projectdetailes([Required(AllowEmptyStrings = false)] int id)
        {
            var tags = await _project.GetProjectDetailes(id);
            return SuccessResponse(tags); ;
        }


        /// <summary>
        /// Add New Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Project")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Project(AddProjectDTO project)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _project.AddProject(adminId1, project);
            return BaseSuccessResponse();
        }


        /// <summary>
        /// Data for DrobDown List
        /// </summary>

        /// <returns></returns>
        //[HttpGet]
        //[Route("Project/AddProjectDropDownsData")]
        //[ProducesResponseType(statusCode: 200, Type = typeof(APIResult<AddProjectDropDownData>))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        //public async Task<BaseAPIResult> GetProjectDropDownsData()
        //{
        //    var result =await _project.GetProjectDropDownsData();
        //    return SuccessResponse(result);
        //}



        /// <summary>
        /// Update project data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Project/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateProject([Required(AllowEmptyStrings = false)] int id, AddProjectDTO project)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _project.UpdateProject(adminId1, id , project);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteProject([Required(AllowEmptyStrings = false)] int id)
        {
            await _project.DeleteProject(id);
            return BaseSuccessResponse();
        }
        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
