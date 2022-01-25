using Meta.IntroApp.DTOs.PRJ_ProjectCategoriesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectCategory.admin
{
    public interface IAdminProjectCategory
    {
        Task<List<GetProjectCategoriesDTO>> GetProjectCategories();

        Task AddProjectCategory(int adminID , ADDProjectCategoriesDTO model);

        Task UpdateProjectCategory(int adminID, int id, ADDProjectCategoriesDTO model);

        Task DeleteProjectCategory(int id);
    }
}
