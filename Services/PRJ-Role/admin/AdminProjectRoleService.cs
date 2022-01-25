using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectRole;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Role.admin
{
    public class AdminProjectRoleService : BaseService, IAdminProjectRole
    {
        private readonly IWebHostEnvironment _env;
        public AdminProjectRoleService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddProjectCRole(int adminId, ADDProjectRoleDTO model)
        {
            var newRole = new PRJProjectRole
            {
                Value = model.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
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
            await AppDbContext.PRJProjectRole.AddAsync(newRole);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectRole(int id)
        {
            var toBeDeleted = await AppDbContext.PRJProjectRole.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJProjectRole.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
        
           
        }

        public async Task<List<GetProjectRolesDTO>> GetProjectRoles()
        {
            var ProjectRoles = await (from role in AppDbContext.PRJProjectRole
                                         .Include(x => x.CreatedByAccount)
                                         .Include(c => c.UpdatedByAccount)
                                      where role.MobMerchantMerchantId == CurrentMerchantId
                                      && role.IsArchive == 0
                                    
                                      select new GetProjectRolesDTO
                                      {
                                          Id = role.Id,
                                          Value = role.Value,
                                          CreatedOn = role.CreatedOn,
                                          CreatedBy = role.CreatedByAccount.FirstName+" "+role.CreatedByAccount.LastName,
                                          UpdatedOn = role.UpdatedOn,
                                          UpdatedBy = role.UpdatedByAccount.FirstName+" "+role.UpdatedByAccount.LastName,
                                          IsArchive = role.IsArchive,
                                          ArchiveDate = role.ArchiveDate
                                      }).ToListAsync();
            return ProjectRoles;
        }

        public async Task UpdateProjectRole(int adminId, int id, ADDProjectRoleDTO model)
        {
            var toBeUpdated = await AppDbContext.PRJProjectRole
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


            AppDbContext.PRJProjectRole.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
