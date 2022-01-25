using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    public class ProjectController : BaseClientController
    {
        private readonly IClientProjectService _projectService;

        public ProjectController(IClientProjectService projectService)
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
            return SuccessResponse(projects); 
        }

        /// <summary>
        ///return project detailes
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

     
    }
}