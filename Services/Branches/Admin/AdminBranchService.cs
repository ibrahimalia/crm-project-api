//using Meta.IntroApp.Models;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminBranchService : BaseService, IAdminBranchesService
    {
        public AdminBranchService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
                 : base(context, httpContextAccessor)
        {
        }

        public async Task AddBranch(AddBranchDTO mobBranch)
        {
            MobBranch branch = new MobBranch
            {
                Address = mobBranch.Address,
                City = mobBranch.City,
                Name = mobBranch.Name,
                IsActive = mobBranch.IsActive,
                IsMain = mobBranch.IsMain
            };
            branch.MerchantId = CurrentMerchantId;

            await AppDbContext.Branches.AddAsync(branch);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteBranch(int id)
        {
            var Branch = await AppDbContext.Branches.Where(p => p.MerchantId == CurrentMerchantId && p.BranchesId == id).FirstOrDefaultAsync();

            //check if the branch is exist
            if (Branch == null)
                throw new ApplicationException(AppExceptions.BranchNotFound);
            //delete it
            AppDbContext.Branches.Remove(Branch);

            //commit changes
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<GetBranchDTO> GetBranchDetailes(int id)
        {
            var branch = await AppDbContext.Branches.Where(o => o.MerchantId == CurrentMerchantId && o.BranchesId == id).FirstOrDefaultAsync();
            if (branch == null)
                throw new ApplicationException(AppExceptions.BranchNotFound);

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

            List<MobBranch> branches = await AppDbContext.Branches.Where(o => o.MerchantId == CurrentMerchantId)
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

        public async Task UpdateBranch(AddBranchDTO branch)
        {
            var oldBranch = await AppDbContext.Branches.Where(p => p.MerchantId == CurrentMerchantId
                                                       && (!CurrentBranchId.HasValue || p.BranchesId == CurrentBranchId)).FirstOrDefaultAsync();

            if (oldBranch != null)
            {
                oldBranch.Name = branch.Name;
                oldBranch.Address = branch.Address;
                oldBranch.City = branch.City;
                oldBranch.IsActive = branch.IsActive;
                oldBranch.IsMain = branch.IsMain;

                //edit the  returned object with new changes
                AppDbContext.Branches.Update(oldBranch);

                //commit changes
                await AppDbContext.SaveChangesAsync();
            }
        }
    }
}