using Meta.IntroApp.DTOs.PRJ_ProjectStatusDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public interface IAdminProjectStatus
    {
        Task<List<GetProjectStatusDTO>> GetProjectStatus();

        Task AddProjectStatus(int admin, AddProjectStatusDTO model);

        Task UpdateProjectStatus(int admin, int id, AddProjectStatusDTO model);

        Task DeleteProjectStatus(int id);
    }
}
