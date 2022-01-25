using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Services.PRJ_Attachement.client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectFollower.Admin
{
    public class AdminProjectFollowerService : BaseService, IAdminProjectFollower
    {
        private readonly IWebHostEnvironment _env;
        public AdminProjectFollowerService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task<List<GetProjectManagerInfo>> GetProjectManger(int projectID)
        {
             var Result = await (from projectFollower in AppDbContext.PRJProjectFollowers
                               
                                .Include(b=>b.ProjectRole)
                                .Include(v=>v.Contact)
                                .Include(z=>z.Project)
                                where projectFollower.MobMerchantMerchantId == CurrentMerchantId 
                                && projectFollower.ProjectId == projectID && projectFollower.ProjectRole.Value=="project_manager" 
                                && projectFollower.IsArchive == 0
                              
                               
                                select new GetProjectManagerInfo
                                {
                                    ContactName = projectFollower.Contact.FullName,
                                    Image = JsonConvert.DeserializeObject<string>(projectFollower.Contact.Photo ?? "").WrapContentUrl()
                                }).ToListAsync();
            return Result; 
        }

        public async Task AddProjectFollower(int adminID, ADDProjectFollowerDTO model)
        {
            
            var ProjectFollower = new PRJProjectFollowers
            {
                ContactsId = model.ContactsId,
                Notes = model.Notes,
                ProjectId = model.ProjectId,
                ProjectLevelId = model.ProjectLevelId,
                PRJProjectRole = model.ProjectRoleId,
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
                ProjectFollower.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJProjectFollowers.AddAsync(ProjectFollower);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task ArchiveProjectFollower(int id)
        {
            var toBeDeleted = await AppDbContext.PRJProjectFollowers.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            toBeDeleted.IsArchive = 1;
            AppDbContext.PRJProjectFollowers.Update(toBeDeleted);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<List<GetProjectFollowerDTO>> GetProjectFollower(int projectID)
        {

            var Result = await (from projectFollower in AppDbContext.PRJProjectFollowers
                                .Include(x=>x.CreatedByAccount)
                                .Include(c=>c.UpdatedByAccount)
                                .Include(s=>s.ProjectLevel)
                                .Include(b=>b.ProjectRole)
                                .Include(v=>v.Contact)
                                .Include(z=>z.Project)
                                where projectFollower.MobMerchantMerchantId == CurrentMerchantId 
                                && projectFollower.ProjectId == projectID && projectFollower.ProjectRole.Value=="project_manager" 
                                && projectFollower.IsArchive == 0
                              
                               
                                select new GetProjectFollowerDTO
                                {
                                    ContactName = projectFollower.Contact.FullName,
                                    Notes = projectFollower.Notes,
                                    ProjectRole = projectFollower.ProjectRole.Value,
                                    ProjectLevel = projectFollower.ProjectLevel.Value,
                                    ProjectName = projectFollower.Project.Name,
                                    Id = projectFollower.Id,
                                    CreatedOn = projectFollower.CreatedOn,
                                    CreatedBy = projectFollower.CreatedByAccount.FirstName+" "+ projectFollower.CreatedByAccount.LastName,
                                    UpdatedOn = projectFollower.UpdatedOn,
                                    UpdatedBy = projectFollower.UpdatedByAccount.FirstName+" "+ projectFollower.UpdatedByAccount.LastName,
                                    IsArchive = projectFollower.IsArchive,
                                    ArchiveDate = projectFollower.ArchiveDate,
                                    Image = JsonConvert.DeserializeObject<string>(projectFollower.Contact.Photo ?? "").WrapContentUrl()
                                }).ToListAsync();
            return Result;
        }

        public async Task UpdateProjectFollower(int adminID, int ProjectFollowerId, ADDProjectFollowerDTO model)
        {
            
            var toBeUpdated = await AppDbContext.PRJProjectFollowers
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == ProjectFollowerId)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.ProjectLevelId = model.ProjectLevelId;
            toBeUpdated.PRJProjectRole = model.ProjectRoleId;
            toBeUpdated.ContactsId = model.ContactsId;       
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


            AppDbContext.PRJProjectFollowers.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<List<GetProjectFollowerInfoDTO>> GetProjectFollowerInfo(int projectID)
        {

            var Result = await(from follower in AppDbContext.PRJProjectFollowers                         
                                .Include(s => s.ProjectLevel)
                                .Include(b => b.ProjectRole)
                                .Include(v => v.Contact)
                            
                               where follower.MobMerchantMerchantId == CurrentMerchantId 
                               && follower.ProjectId == projectID
                               && follower.IsArchive == 0
                        
                          select new GetProjectFollowerInfoDTO
                          {
                              Id = follower.Id,
                              FullName = follower.Contact.FullName,
                              Image = JsonConvert.DeserializeObject<string>(follower.Contact.Photo??"").WrapContentUrl(),
                              InvolvementLevel = follower.ProjectLevel.Value,
                              Role = follower.ProjectRole.Value
                          }).ToListAsync();

            return Result;
    
        }

        public async Task ArchiveProjectFollowers(ICollection<PRJProjectFollowers> projectFollowers)
        {
            if (projectFollowers.Count != 0)
            {
                foreach (var item in projectFollowers)
                {

                    item.IsArchive = 1;
                    AppDbContext.PRJProjectFollowers.Update(item);
                    await AppDbContext.SaveChangesAsync();
                }
              

            }
        }
    }

}