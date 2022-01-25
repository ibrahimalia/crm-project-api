using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Project.admin
{
   public interface IAdminProject
   {
        Task<List<GetProjectDTO>> GetProjects(PRJProjectFilter projectFilter);

        Task<List<GetTreeViewOfProjectsDTO>> GetTreeViewOfProjects(PRJProjectFilter projectFilter);
        Task<GetProjectDetailesInfo> GetProjectDetailes(int id);

        Task AddProject(int adminId ,AddProjectDTO project);

        Task UpdateProject(int adminId ,int id, AddProjectDTO project);

        Task DeleteProject(int id);
        Task<AddProjectDropDownData> GetProjectDropDownsData();

    }
}
