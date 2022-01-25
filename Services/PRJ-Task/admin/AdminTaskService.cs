using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using Meta.IntroApp.DTOs.PRJ_Tasks;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Services.PRJ_Attachement.admin;
using Meta.IntroApp.Services.PRJ_Project.admin;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using Meta.IntroApp.Services.PRJ_Role.admin;
using Meta.IntroApp.Services.PRJ_TaskFollower;
using Meta.IntroApp.Services.PRJ_TaskHistory;
using Meta.IntroApp.Services.PRJ_TaskStatus;
using Meta.IntroApp.Services.Utility.ProjectManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Task.admin
{
    public class AdminTaskService : BaseService, IAdminTask
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAdminTaskFollowers _taskFollowers;
        private readonly IAdminProjectAttachements _attachements;
        private readonly IAdminTaskHistory _TaskHistory;
        private readonly IAdminProjectRole _role;
        private readonly IAdminTaskStatus _status;
      
        public AdminTaskService(MetaITechDbContext context,
                                IWebHostEnvironment env,
                                //IAdminProject project,
                                IHttpContextAccessor httpContextAccessor,
                                IAdminTaskFollowers taskFollowers,
                                IAdminProjectAttachements attachements,
                                IAdminProjectRole role,
                                IAdminTaskStatus status,
                                IAdminTaskHistory TaskHistory
                               )
            : base(context, httpContextAccessor)
        {
            _env = env;
            _taskFollowers = taskFollowers;
            _attachements = attachements;
            //_project = project;
            _role = role;
            _status = status;
            _TaskHistory = TaskHistory;
       
        }

        public async Task AddTask(int adminId, AddTaskDTO task)
        {
            var newTask = new PRJTask
            {
                IsMajor = task.IsMajor,
                Name = task.Name,
                DuetDate = task.DuetDate,
                Description = task.Description,
                OwnerId = task.OwnerId,
                PRJTaskId = task.PRJTaskId,
                ProjectRoleId = task.ProjectRoleId,
                ProjectId = task.ProjectId,
                StartDate = task.StartDate,
                ActualFinishDate = null,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = task.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId,
                TaskStatusId = task.TaskStatusId,
                Label = task.Label
            };
            if (task.IsArchive == 1)
            {
                newTask.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJTask.AddAsync(newTask);
            await AppDbContext.SaveChangesAsync();


            TaskHistoryDTO TaskLog = new TaskHistoryDTO
            {
                Title = "Add Task",
                Category = "Task: " + task.Name + " => has been created",
                TaskId = AppDbContext.PRJProject.OrderByDescending(x => x.Id).Select(c => c.Id).FirstOrDefault(),
                CreatedBy = adminId,
                CreatedOn = DateTime.Now,
                
            };


            TaskPublisher pub = new TaskPublisher();
            TaskSubscriber sub = new TaskSubscriber(_TaskHistory);
            sub.Subscribe(pub);
            pub.Notify(TaskLog);

        }

        public async Task ArchiveTask(int id)
        {
            var toBeDeleted = await AppDbContext.PRJTask.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.UnExpectedError);

            var toBeDeleted1 = await AppDbContext.PRJTask.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.PRJTaskId == id).FirstOrDefaultAsync();
            if (toBeDeleted1 != null)

                throw new ApplicationException(AppExceptions.UnExpectedError);

            toBeDeleted.IsArchive = 1;
      
            //archive taskfollowers
            await _taskFollowers.ArchiveTaskFollowers(toBeDeleted.TaskFollowers);
            //save
            AppDbContext.PRJTask.Update(toBeDeleted);
            await AppDbContext.SaveChangesAsync();

            TaskHistoryDTO TaskLog = new TaskHistoryDTO
            {
                Title = "Archive Task",
                Category = "Task: " + toBeDeleted.Name + " => has been Archived",
                TaskId = toBeDeleted.Id,
                //CreatedBy = adminId,
                CreatedOn = DateTime.Now,

            };


            TaskPublisher pub = new TaskPublisher();
            TaskSubscriber sub = new TaskSubscriber(_TaskHistory);
            sub.Subscribe(pub);
            pub.Notify(TaskLog);
        }

        public async Task<List<GetTasksDTO>> NewGetTasks(int projectId, PRJTaskFilter TaskFilter)
        {
          var validFilter = new PRJTaskFilter(TaskFilter.PageNumber, TaskFilter.PageSize , TaskFilter.DueDate , TaskFilter.Status);

            var tasks = await (from task in AppDbContext.PRJTask
                      
                              
                                .Include(x => x.TaskStatus)
                                .Include(x => x.Project)
                               
                               where task.MobMerchantMerchantId == CurrentMerchantId 
                               && task.ProjectId == projectId 
                               && task.IsArchive == 0
                                                     
                           

                               select new GetTasksDTO
                               {
                                   Id = task.Id,
                                   CreatedBy = task.CreatedByAccount.FirstName + " " + task.CreatedByAccount.LastName,
                                   CreatedOn = task.CreatedOn,
                                   Name = task.Name,
                                   Description = task.Description,
                                   Owner = task.Owner.FullName,
                                   IsMajor = task.IsMajor,
                                   TaskStatus = task.TaskStatus.Value,
                                   ProjectRole = task.ProjectRole.Value,
                                   DuetDate = task.DuetDate,
                                   IsArchive = task.IsArchive,
                                   ArchiveDate = task.ArchiveDate,
                                   StartDate = task.StartDate,                                 
                                   ActualFinishDate = task.ActualFinishDate,
                                   UpdatedBy = task.UpdatedByAccount.FirstName + " " + task.UpdatedByAccount.LastName,
                                   
                                   UpdatedOn = task.UpdatedOn,
                                   ProjectName = task.Project.Name,
                                   TaskFollowers = _taskFollowers.GetTaskFollowersInfo(task.Id).Result,
                                   
                               })
                               .ToListAsync();
            if (tasks.Count == 0)
            {
                return null;
            }

            if (TaskFilter.DueDate != null)
                tasks = tasks.Where(p => p.DuetDate == TaskFilter.DueDate).ToList();
            if (TaskFilter.Status != null)
                tasks = tasks.Where(p => p.TaskStatus == TaskFilter.Status).ToList();
   
            return tasks;   
        }

        public async Task<GetTaskDTO> GetTaskDetailes(int id)
        {
         
            var result = await (from task in AppDbContext.PRJTask
                                 .Include(x => x.CreatedByAccount)
                                .Include(c => c.UpdatedByAccount)
                                .Include(a => a.ProjectRole)
                                .Include(d => d.TaskStatus)
                                .Include(e => e.Project)
                                .Include(e1 => e1.Owner)
                                where task.MobMerchantMerchantId == CurrentMerchantId 
                                && task.Id == id
                                && task.IsArchive == 0
                           

                               select new GetTaskDTO
                               {
                                   Id = task.Id,
                                   CreatedBy = task.CreatedByAccount.FirstName+" "+ task.CreatedByAccount.LastName,
                                   CreatedOn = task.CreatedOn,
                                   Name = task.Name,
                                   Description = task.Description,
                                   Owner = task.Owner.FullName,
                                   IsMajor = task.IsMajor,
                                   TaskStatus = task.TaskStatus.Value,
                                   ProjectRole = task.ProjectRole.Value,                                  
                                   DuetDate = task.DuetDate,
                                   IsArchive = task.IsArchive,
                                   ArchiveDate = task.ArchiveDate,
                                   StartDate = task.StartDate,
                                   ParentTask = task.PRJTaskId +"", 
                                   ActualFinishDate = task.ActualFinishDate,
                                   UpdatedBy = task.UpdatedByAccount.FirstName+" "+task.UpdatedByAccount.LastName,
                                   UpdatedOn = task.UpdatedOn,
                                   ProjectName = task.Project.Name,
                                   TaskFollowers = _taskFollowers.GetTaskFollowersInfo(task.Id).Result,
                                   SubTasksCount = AppDbContext.PRJTask.Where(x => x.PRJTaskId == task.Id).Count(),
                                   SubTasks = GetSubTasks(id).Result,
                                   Attachements = _attachements.GetTaskAttachements(task.Id).Result

                               })
                               .FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            result.ParentTask = result.ParentTask == "" ? null : AppDbContext.PRJTask.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == Convert.ToInt32(result.ParentTask)).Select(c => c.Name).FirstOrDefault();
            return  result;

           
        }

        public async Task<List<GetTasksDTO>> GetTasks(int projectId , PRJTaskFilter TaskFilter)
        {
            
            var validFilter = new PRJTaskFilter(TaskFilter.PageNumber, TaskFilter.PageSize , TaskFilter.DueDate , TaskFilter.Status);

            var tasks = await (from task in AppDbContext.PRJTask
                                .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.ProjectRole)
                                .Include(x => x.TaskStatus)
                                .Include(x => x.Project)
                                .Include(x => x.Owner)
                               where task.MobMerchantMerchantId == CurrentMerchantId 
                               && task.ProjectId == projectId 
                               && task.IsArchive == 0
                                                     
                           

                               select new GetTasksDTO
                               {
                                   Id = task.Id,
                                   CreatedBy = task.CreatedByAccount.FirstName + " " + task.CreatedByAccount.LastName,
                                   CreatedOn = task.CreatedOn,
                                   Name = task.Name,
                                   Description = task.Description,
                                   Owner = task.Owner.FullName,
                                   IsMajor = task.IsMajor,
                                   TaskStatus = task.TaskStatus.Value,
                                   ProjectRole = task.ProjectRole.Value,
                                   DuetDate = task.DuetDate,
                                   IsArchive = task.IsArchive,
                                   ArchiveDate = task.ArchiveDate,
                                   StartDate = task.StartDate,                                 
                                   ActualFinishDate = task.ActualFinishDate,
                                   UpdatedBy = task.UpdatedByAccount.FirstName + " " + task.UpdatedByAccount.LastName,
                                   SubTasksCount = AppDbContext.PRJTask.Where(x => x.PRJTaskId == task.Id).Count(), 
                                   UpdatedOn = task.UpdatedOn,
                                   ProjectName = task.Project.Name,
                                   TaskFollowers = _taskFollowers.GetTaskFollowersInfo(task.Id).Result,
                                   
                               })
                               .ToListAsync();
            if (tasks.Count == 0)
            {
                return null;
            }

            if (TaskFilter.DueDate != null)
                tasks = tasks.Where(p => p.DuetDate == TaskFilter.DueDate).ToList();
            if (TaskFilter.Status != null)
                tasks = tasks.Where(p => p.TaskStatus == TaskFilter.Status).ToList();
   
            return  tasks;
        }

        public async Task UpdateTask(int adminId, int id, AddTaskDTO task)
        {
           
            var toBeUpdated = await AppDbContext.PRJTask
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }
            toBeUpdated.IsMajor = task.IsMajor;
            toBeUpdated.OwnerId = task.OwnerId;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = task.IsArchive;
            toBeUpdated.Name = task.Name;
            toBeUpdated.DuetDate = task.DuetDate;
            toBeUpdated.Description = task.Description;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.TaskStatusId = task.TaskStatusId;
            toBeUpdated.StartDate = task.StartDate;
            toBeUpdated.ActualFinishDate = task.ActualFinishDate;
            toBeUpdated.ProjectRoleId = task.ProjectRoleId;
            toBeUpdated.ProjectId = task.ProjectId;
            

            if (task.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }
            AppDbContext.PRJTask.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();

            TaskHistoryDTO TaskLog = new TaskHistoryDTO
            {
                Title = "Update Task",
                Category = "Task: " + toBeUpdated.Name + " => has been Updated",
                TaskId = toBeUpdated.Id,
                //CreatedBy = adminId,
                CreatedOn = DateTime.Now,

            };


            TaskPublisher pub = new TaskPublisher();
            TaskSubscriber sub = new TaskSubscriber(_TaskHistory);
            sub.Subscribe(pub);
            pub.Notify(TaskLog);
        }

        public async Task<List<GetSubTasksDTO>> GetSubTasks(int TaskId)
        {

            var tasks = await (from task in AppDbContext.PRJTask
                               .Include(x=>x.TaskStatus)
                               where task.MobMerchantMerchantId == CurrentMerchantId 
                               && task.ProjectId == TaskId
                               && task.IsArchive == 0
                              

                               select new GetSubTasksDTO
                               {
                                   Id = task.Id,                              
                                   Name = task.Name,   
                                   TaskStatus = task.TaskStatus.Value,                               
                                   DuetDate = task.DuetDate,                                
                                   StartDate = task.StartDate,
                                    ActualFinishDate = task.ActualFinishDate,                                 
                                   TaskFollowers = _taskFollowers.GetTaskFollowersInfo(task.Id).Result
                               }).ToListAsync();

            return tasks;
        }

        public async Task<TaskDropDownsDTO> GetTaskDropDownsData()
        {
            var Followers = await AppDbContext.PRJContacts.Where(x => x.MobMerchantMerchantId == CurrentMerchantId).Select(c => c.FullName).ToListAsync();
            var projects =await AppDbContext.PRJProject.ToListAsync();
            var roles = await _role.GetProjectRoles();
            var status = await _status.GetTaskStatus();

            var result = new TaskDropDownsDTO
            {
                ProjectRoles = roles.Select(x => x.Value).ToList(),
                Projects = projects.Select(x => x.Name).ToList(),
                TaskOwners = Followers,
                TaskStatus = status.Select(x => x.Value).ToList()
      
            };
            return result;
        }

        public async Task ArchiveTasks(ICollection<PRJTask> tasks)
        {
            if (tasks.Count != 0)
            {
                foreach (var item in tasks)
                {
                    item.IsArchive = 1;
               
                   await _taskFollowers.ArchiveTaskFollowers(item.TaskFollowers);

                }
              
            }
        }
    }
}

