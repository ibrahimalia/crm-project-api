//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Localizations.AppExceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientBranchService : BaseService, IClientBranches
    {
        public ClientBranchService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
                 : base(context, httpContextAccessor)
        {
        }

        public async Task<GetBranchDTO> GetBranchDetailes(int id)
        {
            var branch = await AppDbContext.Branches.Where(o => o.MerchantId == CurrentMerchantId
                                                             && o.BranchesId == id).FirstOrDefaultAsync();
            if (branch == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);

            GetBranchDTO result = new GetBranchDTO
            {
                Id = branch.BranchesId,
                Address = branch.Address,
                City = branch.City,
                Name = branch.Name,
                IsMain = branch.IsMain,
                IsActive = branch.IsActive
            };
            return result;
        }

        public async Task<List<GetBranchDTO>> GetBranches(PaginationFilterDTO filter)
        {
            var validFilter = new PaginationFilterDTO(filter.PageNumber, filter.PageSize);

            var branches = await AppDbContext.Branches.Where(o => o.MerchantId == CurrentMerchantId && o.IsActive == 1)
                                          .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                          .Take(validFilter.PageSize)
                                          .ToListAsync();

            List<GetBranchDTO> result = new List<GetBranchDTO>();
            if (branches.Count == 0)
                throw new ApplicationException(AppExceptions.UnExpectedError);

            return branches.ConvertAll(c => new GetBranchDTO
            {
                Id = c.BranchesId,
                Address = c.Address,
                City = c.City,
                Name = c.Name,
                IsActive = c.IsActive,
                IsMain = c.IsMain
            });
        }
    }
}