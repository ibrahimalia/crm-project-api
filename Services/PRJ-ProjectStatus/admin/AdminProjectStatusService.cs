using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectStatusDTO;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectStatus.admin
{
    public class AdminProjectStatusService : BaseService, IAdminProjectStatus
    {
        private readonly IWebHostEnvironment _env;
        public AdminProjectStatusService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddProjectStatus(int adminID, AddProjectStatusDTO model)
        {
           
            var newRole = new PRJProjectStatus
            {
                Value = model.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = adminID,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = model.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId
            };
            if (model.IsArchive == 1)
            {
                newRole.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJProjectStatus.AddAsync(newRole);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectStatus(int id)
        {
            var toBeDeleted = await AppDbContext.PRJProjectStatus.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJProjectStatus.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
           
           
        }

        public async Task<List<GetProjectStatusDTO>> GetProjectStatus()
        {
            var ProjectStates = await (from State in AppDbContext.PRJProjectStatus
                                          .Include(x => x.CreatedByAccount)
                                          .Include(c => c.UpdatedByAccount)
                                       where State.MobMerchantMerchantId == CurrentMerchantId
                                       && State.IsArchive == 0

            select new GetProjectStatusDTO
            {
                Id = State.Id,
                Value = State.Value,
                CreatedOn = State.CreatedOn,
                CreatedBy = State.CreatedByAccount.FirstName+" "+ State.CreatedByAccount.LastName,
                UpdatedOn = State.UpdatedOn,
                UpdatedBy = State.UpdatedByAccount.FirstName+" "+ State.UpdatedByAccount.LastName,
                IsArchive = State.IsArchive,
                ArchiveDate = State.ArchiveDate
            }).ToListAsync();
            return ProjectStates;
        }

        public async Task UpdateProjectStatus(int adminId, int id, AddProjectStatusDTO model)
        {
            var toBeUpdated = await AppDbContext.PRJProjectStatus
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = model.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = model.IsArchive;
            if (model.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJProjectStatus.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
