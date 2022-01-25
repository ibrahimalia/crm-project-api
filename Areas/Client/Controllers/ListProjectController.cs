using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class ListProjectController : BaseClientController 
    {
        private readonly MetaITechDbContext _appDbContext;

        public ListProjectController(MetaITechDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        } 

        


        /// <summary>
        /// tree of projects
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
     //   [Authorize(Roles = "Admin")]     
        [HttpGet("treeProject")]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(APIResult<RegisterUserResultDTO>))]
        [ProducesResponseType(500, StatusCode = 200, Type = typeof(BaseAPIResult))]
        public async Task<List<GetProjecTreetDTO>> GetProjectTree()
        {
            var Result =await (from project in _appDbContext.PRJProject
              
                select new GetProjecTreetDTO
                {
                    ProjectId = project.Id,
                    ProjectName = project.Name,
                
                }).ToListAsync();
            foreach (var item in Result)
            {
                item.SubProjects =  GetSubProject(item.ProjectId).Result;
            }
            return Result;
        }
         [HttpGet("tree")]
        public async Task<List<SubTreeProjectsDTO>> GetSubProject(int projectId)
        {
            var Results = await (from project in _appDbContext.PRJProject
                      
                    where project.PRJProjectId == projectId
                               
                    select new SubTreeProjectsDTO
                    {
                        SubProjectId = project.Id,
                        ProjectName = project.Name,
                      
                    })
                .ToListAsync();
            return Results;

        }
    }
}