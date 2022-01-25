//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminProjectService
    {
        Task<List<ProjectDTO>> GetProjects(PaginationFilterDTO filter);

        Task<ProjectDTO> GetProjectDetailes(int? id);

        Task AddProject(AddEditProjectDTO project);

        Task UpdateProject(int id, AddEditProjectDTO project);

        Task DeleteProject(int id);
    }
}