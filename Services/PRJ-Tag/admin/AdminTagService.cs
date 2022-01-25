using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_Tag;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Tag.admin
{
    public class AdminTagService : BaseService, ITagAdmin
    {
        private readonly IWebHostEnvironment _env;
        public AdminTagService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddTag(int adminId ,AddTagDTO tag)
        {
           
            var newTag = new PRJTAG
            {
                Value = tag.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = tag.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId
            };
            if (tag.IsArchive == 1)
            {
                newTag.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJTAG.AddAsync(newTag);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteTag(int id)
        {
            var toBeDeleted = await AppDbContext.PRJTAG.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {

                AppDbContext.PRJTAG.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
       
        }

        public async Task<List<GetTagDTO>> GetTags()
        {

            var tags = await (from tag in AppDbContext.PRJTAG
                                 .Include(x => x.CreatedByAccount)
                                .Include(c => c.UpdatedByAccount)
                              where tag.MobMerchantMerchantId == CurrentMerchantId && tag.IsArchive==0


                              select new GetTagDTO
                              {
                                  Id = tag.Id,
                                  Value = tag.Value,
                                  CreatedOn = tag.CreatedOn,
                                  CreatedBy = tag.CreatedByAccount.FirstName + " " + tag.CreatedByAccount.LastName,
                                  UpdatedOn = tag.UpdatedOn,
                                  UpdatedBy = tag.UpdatedByAccount.FirstName + " "+ tag.UpdatedByAccount.LastName,
                                  IsArchive = tag.IsArchive,
                                  ArchiveDate = tag.ArchiveDate
                              }).ToListAsync();
            return tags;
        }

        public async Task UpdateTag(int adminId ,int id, AddTagDTO tag)
        {

            var toBeUpdated = await AppDbContext.PRJTAG
                             .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                             .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = tag.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = tag.IsArchive;
            if (tag.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJTAG.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
