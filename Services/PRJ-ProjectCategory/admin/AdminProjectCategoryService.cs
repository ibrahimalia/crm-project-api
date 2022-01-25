using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectCategoriesDTO;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectCategory.admin
{
    public class AdminProjectCategoryService : BaseService, IAdminProjectCategory
    {
        private readonly IWebHostEnvironment _env;

        public AdminProjectCategoryService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddProjectCategory(int adminID, ADDProjectCategoriesDTO model)
        {
            var newCategory = new PRJProjectCategory
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
                newCategory.ArchiveDate = DateTime.Now;
            }
          
            await AppDbContext.PRJProjectCategory.AddAsync(newCategory);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectCategory(int id)
        {
            var toBeDeleted = await AppDbContext.PRJProjectCategory.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJProjectCategory.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);

            }


        }

        public async Task<List<GetProjectCategoriesDTO>> GetProjectCategories()
        {

            var categories = await (from c in AppDbContext.PRJProjectCategory
                                    .Include(x=>x.CreatedByAccount)
                                    .Include(c=>c.UpdatedByAccount)                                    
                                    where c.MobMerchantMerchantId == CurrentMerchantId && c.IsArchive == 0

                                    select new GetProjectCategoriesDTO
                                    {

                                        Id = c.Id,
                                        Value = c.Value,
                                        CreatedOn = c.CreatedOn,
                                        CreatedBy = c.CreatedBy != null ? c.CreatedByAccount.FirstName+" "+c.CreatedByAccount.LastName :"",
                                        UpdatedOn = c.UpdatedOn,
                                        UpdatedBy = c.UpdatedBy != null ? c.UpdatedByAccount.FirstName +" "+c.UpdatedByAccount.LastName:"",
                                        IsArchive = c.IsArchive,
                                        ArchiveDate = c.ArchiveDate
                                    }).ToListAsync();
            return categories;
        }

        public async Task UpdateProjectCategory(int adminID, int id, ADDProjectCategoriesDTO model)
        {
            
            var toBeUpdated = await AppDbContext.PRJProjectCategory
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
            toBeUpdated.UpdatedBy = adminID;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = model.IsArchive;
            if (model.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJProjectCategory.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}

