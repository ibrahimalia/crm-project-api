using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_jobPosition;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_JobPosition.admin
{
    public class AdminJobPositionService : BaseService, IAdminJobPosition
    {
        private readonly IWebHostEnvironment _env;
        public AdminJobPositionService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddJobPosition(int AdminID, AddJobPositionDTO jobPosition)
        {
          
            var newPosition = new PRJJobPosition
            {
                Value = jobPosition.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = AdminID,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = jobPosition.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId=CurrentMerchantId
            };
            if (jobPosition.IsArchive == 1)
            {
                newPosition.ArchiveDate = DateTime.Now;
            }
         
            await AppDbContext.PRJJobPosition.AddAsync(newPosition);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteJobPosition(int id)
        {
            var toBeDeleted = await AppDbContext.PRJJobPosition.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJJobPosition.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
         
       
        }

        public async Task<List<GetJobPositions>> GetJobPositions()
        {
            var positions = await (from position in AppDbContext.PRJJobPosition
                                    .Include(x => x.CreatedByAccount)
                                .Include(c => c.UpdatedByAccount)
                                   where position.MobMerchantMerchantId == CurrentMerchantId && position.IsArchive == 0

                                   select new GetJobPositions
                                   {

                                       Id = position.Id,
                                       Value = position.Value,
                                       CreatedOn = position.CreatedOn,
                                       CreatedBy = position.CreatedByAccount.FirstName + " " + position.CreatedByAccount.LastName,
                                       UpdatedOn = position.UpdatedOn,
                                       UpdatedBy = position.UpdatedByAccount.FirstName + " " + position.UpdatedByAccount.LastName,
                                       IsArchive = position.IsArchive,
                                       ArchiveDate = position.ArchiveDate
                                   }).ToListAsync();
            return positions;
        }

        public async Task UpdateJobPosition(int AdminID, int id, AddJobPositionDTO jobPosition)
        {
           
            var toBeUpdated = await AppDbContext.PRJJobPosition
                             .Where(x => x.MobMerchantMerchantId == CurrentMerchantId  && x.Id == id)
                             .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = jobPosition.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = AdminID;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = jobPosition.IsArchive;
            if (jobPosition.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJJobPosition.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
