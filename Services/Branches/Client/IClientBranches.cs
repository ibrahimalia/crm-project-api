//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientBranches
    {
        Task<List<GetBranchDTO>> GetBranches(PaginationFilterDTO filter);

        Task<GetBranchDTO> GetBranchDetailes(int id);
    }
}