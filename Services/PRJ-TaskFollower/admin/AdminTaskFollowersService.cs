using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskFollower
{
    public class AdminTaskFollowersService : BaseService, IAdminTaskFollowers
    {
        private readonly IWebHostEnvironment _env;
        public AdminTaskFollowersService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddTaskFollower(int adminId, AddTaskFollowersDTO model)
        {
            var newTaskFollower = new PRJTaskFollower
            {
               ProjectId = model.ProjectId,
               ContactsId = model.ContactsId,
               Notes = model.Notes,
               PRJTaskId = model.PRJTaskId,
               TaskLevelId = model.TaskLevelId,
               ProjectRoleId = model.ProjectRoleId,               
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
                newTaskFollower.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJTaskFollower.AddAsync(newTaskFollower);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task ArchiveTaskFollower(int id)
        {
            var toBeDeleted = await AppDbContext.PRJTaskFollower.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);
            toBeDeleted.IsArchive = 1;
            AppDbContext.PRJTaskFollower.Update(toBeDeleted);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task ArchiveTaskFollowers(ICollection<PRJTaskFollower> taskFollowers)
        {
            if (taskFollowers != null)
            {
                foreach (var item in taskFollowers)
                {
                    item.IsArchive = 1;
                }
                AppDbContext.PRJTaskFollower.UpdateRange(taskFollowers);
                await AppDbContext.SaveChangesAsync();
            }
        }
        

        public async Task<GetTaskFollowersDTO> GetTaskFollowerDetailes(int id)
        {
            
            var result = await (from taskFollower in AppDbContext.PRJTaskFollower
                                .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)                                
                                .Include(x => x.ProjectRole)
                                .Include(x => x.Contacts)
                                .Include(x => x.TaskLevel)
                                
                                where taskFollower.MobMerchantMerchantId == CurrentMerchantId
                                && taskFollower.Id == id
                                && taskFollower.IsArchive == 0
                                select new GetTaskFollowersDTO
                                {
                                    Id = taskFollower.Id,
                                    CreatedBy = taskFollower.CreatedByAccount.FirstName+" "+ taskFollower.CreatedByAccount.LastName,
                                    CreatedOn = taskFollower.CreatedOn,
                                    FullName = taskFollower.Contacts.FullName,
                                    ProjectRole = taskFollower.ProjectRole.Value,
                                    ProjectName = taskFollower.Project.Name,
                                    TaskLevel = taskFollower.TaskLevel.Value,
                                    IsArchive = taskFollower.IsArchive,
                                    ArchiveDate = taskFollower.ArchiveDate,
                                    //Task = taskFollower.Task.Name,
                                    UpdatedBy = taskFollower.UpdatedByAccount.FirstName+" "+ taskFollower.UpdatedByAccount.LastName,
                                    UpdatedOn = taskFollower.UpdatedOn
                                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<GetTaskFollowersDTO>> GetTaskFollowers(int taskID)
        {
            var result = await (from taskFollower in AppDbContext.PRJTaskFollower .Include(x => x.CreatedByAccount)
                                .Include(c => c.UpdatedByAccount)
                                .Include(b => b.ProjectRole)
                                .Include(v => v.Contacts)
                                where taskFollower.MobMerchantMerchantId == CurrentMerchantId
                             && taskFollower.PRJTaskId == taskID
                             && taskFollower.IsArchive == 0
                                select new GetTaskFollowersDTO
                                {
                                    Id = taskFollower.Id,
                                    CreatedBy = taskFollower.CreatedByAccount.FirstName + " " + taskFollower.CreatedByAccount.LastName,
                                    CreatedOn = taskFollower.CreatedOn,
                                    FullName = taskFollower.Contacts.FullName,
                                    ProjectRole = taskFollower.ProjectRole.Value,
                                    ProjectName = taskFollower.Project.Name,
                                    TaskLevel = taskFollower.TaskLevel.Value,
                                    IsArchive = taskFollower.IsArchive,
                                    ArchiveDate = taskFollower.ArchiveDate,
                                    //Task = taskFollower.Task.Name,
                                    UpdatedBy = taskFollower.UpdatedByAccount.FirstName + " " + taskFollower.UpdatedByAccount.LastName,
                                    UpdatedOn = taskFollower.UpdatedOn
                                }).ToListAsync();

            return result;
        }

        public async Task<List<GetTaskFollowersInfoDTO>> GetTaskFollowersInfo(int taskID)
        {
            var result = await (from taskFollower in AppDbContext.PRJTaskFollower
                                .Include(x=>x.Contacts)
                                .Include(x1 =>x1.ProjectRole)
                                .Include(x2=>x2.TaskLevel)
                                where taskFollower.MobMerchantMerchantId == CurrentMerchantId
                                && taskFollower.PRJTaskId == taskID
                                && taskFollower.IsArchive == 0
                        
                                select new GetTaskFollowersInfoDTO
                                {
                                    Id = taskFollower.Id,
                                    Image = taskFollower.Contacts.Photo,
                                    FullName = taskFollower.Contacts.FullName,
                                    ProjectRole = taskFollower.ProjectRole.Value,                                    
                                    TaskLevel = taskFollower.TaskLevel.Value

                                }).ToListAsync();

            return result;
        }

        public async Task UpdateTaskFollower(int adminId, int id, AddTaskFollowersDTO model)
        {
           
            var toBeUpdated = await AppDbContext.PRJTaskFollower
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }
            toBeUpdated.TaskLevelId = model.TaskLevelId;
            toBeUpdated.PRJTaskId = model.PRJTaskId;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = model.IsArchive;
            toBeUpdated.Notes = model.Notes;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
         
            toBeUpdated.ProjectRoleId = model.ProjectRoleId;
            toBeUpdated.ProjectId = model.ProjectId;
            toBeUpdated.ContactsId = model.ContactsId;
            

            if (model.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }
            AppDbContext.PRJTaskFollower.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
