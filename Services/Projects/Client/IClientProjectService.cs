using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientProjectService
    {
        Task<List<ProjectDTO>> GetProjects(PaginationFilterDTO filter);

        Task<ProjectDTO> GetProjectDetailes(int? id);
    }
}