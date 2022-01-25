using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_InvolvementLevel;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_InvolvementLevel.admin
{
    public class AdminInvolvementLevelService : BaseService, IAdminInvolvementLevel
    {
        private readonly IWebHostEnvironment _env;

        public AdminInvolvementLevelService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddLevel(int clientID, AddInvolvementLevelDTO level)
        {
             
            var newLevel = new PRJInvolvementLevel
            {
                Value = level.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = clientID,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = level.IsArchive,
                ArchiveDate = null,
               MobMerchantMerchantId = CurrentMerchantId 
            };
            if (level.IsArchive == 1)
            {
                newLevel.ArchiveDate = DateTime.Now;
            }
          
            await AppDbContext.PRJInvolvementLevel.AddAsync(newLevel);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteLevel(int id)
        {
            var toBeDeleted = await AppDbContext.PRJInvolvementLevel.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJInvolvementLevel.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }


         
        }

        public async Task<List<GetInvolvementLevelDTO>> GetLevels()
        {
           
            var levels = await (from level in AppDbContext.PRJInvolvementLevel
                                .Include(x=>x.CreatedByAccount)
                                .Include(c=>c.UpdatedByAccount)
                                where level.MobMerchantMerchantId == CurrentMerchantId && level.IsArchive == 0

                                select new GetInvolvementLevelDTO
                                {
                                    Id = level.Id,
                                    Value = level.Value,
                                    CreatedOn = level.CreatedOn,
                                    CreatedBy = level.CreatedBy != null ? level.CreatedByAccount.FirstName + " "+ level.CreatedByAccount.LastName : "",
                                    UpdatedOn = level.UpdatedOn,
                                    UpdatedBy = level.UpdatedBy != null ? level.UpdatedByAccount.FirstName + " " + level.UpdatedByAccount.LastName : "",
                                    IsArchive = level.IsArchive,
                                    ArchiveDate = level.ArchiveDate
                                }).ToListAsync();
            return levels;
        }

        public async Task UpdateLevel(int clientID, int id, AddInvolvementLevelDTO level)
        {
            
            var toBeUpdated = await AppDbContext.PRJInvolvementLevel
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = level.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = clientID;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = level.IsArchive;
            if (level.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJInvolvementLevel.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}