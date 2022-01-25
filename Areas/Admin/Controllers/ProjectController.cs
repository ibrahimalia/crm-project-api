using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class ProjectController : BaseAdminController
    {
        private readonly IAdminProjectService _projectService;

        public ProjectController(IAdminProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Get all projects for specific merchant
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<ProjectDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjects([FromQuery] PaginationFilterDTO filter)
        {
            var projects = await _projectService.GetProjects(filter);
            return SuccessResponse(projects); ;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<ProjectDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetProjectDetails([Required(AllowEmptyStrings = false)] int? id)
        {
            var result = await _projectService.GetProjectDetailes(id);
            return SuccessResponse(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Projects")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddProjects(AddEditProjectDTO project)
        {
            await _projectService.AddProject(project);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Projects/{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateProject([Required(AllowEmptyStrings = false)] int id, AddEditProjectDTO model)
        {
            await _projectService.UpdateProject(id, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteProject([Required] int? id)
        {
            await _projectService.DeleteProject(id.Value);
            return BaseSuccessResponse();
        }
    }
}