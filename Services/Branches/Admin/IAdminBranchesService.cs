using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminBranchesService
    {
        Task<List<GetBranchDTO>> GetBranches(PaginationFilterDTO filter);

        Task<GetBranchDTO> GetBranchDetailes(int id);

        Task AddBranch(AddBranchDTO mobBranch);

        Task UpdateBranch(AddBranchDTO branch);

        Task DeleteBranch(int id);
    }
}