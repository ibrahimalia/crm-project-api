using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.DTOs.PRJ_Projects;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using Meta.IntroApp.DTOs.PRJ_Tasks;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Services.PRJ_Attachement.admin;
using Meta.IntroApp.Services.PRJ_Attachement.client;
using Meta.IntroApp.Services.PRJ_ProjectCategory.admin;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using Meta.IntroApp.Services.PRJ_Task.admin;
using Meta.IntroApp.Services.Utility.ProjectManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Project.admin
{
    public class RRJAdminProjectService : BaseService, IAdminProject 
    {
        private readonly IWebHostEnvironment _env;

        public IAdminProjectFollower _ProjectFollower { get; }

        private readonly IAdminProjectCategory _category;
        private readonly IAdminProjectStatus _status;
       
        private readonly IAdminTask _task;
     
  
        private readonly IAdminProjectAttachements _adminProjectAttachements;
        private readonly IAdminProjectHistory _projectHistory;

        public RRJAdminProjectService(MetaITechDbContext context,
                                      IAdminProjectFollower projectFollower,
                                      IWebHostEnvironment env,
                                      IHttpContextAccessor httpContextAccessor,
                                      IAdminProjectCategory category,
                                      IAdminProjectStatus status,                                     
                                      IAdminTask task,                                                                        
                                      IAdminProjectAttachements adminProjectAttachements,
                                      IAdminProjectHistory projectHistory)
            : base(context, httpContextAccessor)
        {
            _env = env;
            _ProjectFollower = projectFollower;
            _category = category;
            _status = status;           
            _task = task;
            _adminProjectAttachements = adminProjectAttachements;
            _projectHistory = projectHistory;
        }

        public async Task AddProject(int adminId ,AddProjectDTO project)
        {
          
            var newProject = new PRJProject
            {
                PRJProjectId = project.ParentProjectId,
                ProjectStatusId = project.ProjectStatusId,
                ProjectCategoryId = project.ProjectCategoryId,
                StartDate = project.StartDate,
                EndDate = project.DueDate,
                Logo = JsonConvert.SerializeObject(project.Logo),
                Name = project.ProjectName,
                Description = project.Description,
                CustomerName = project.CustomerName,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = project.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId,
                Label = project.Label,
                Attachements = new List<PRJAttachements> 
                {
                    new PRJAttachements
                    {
                        Path = project.Attachement.Path,
                        Title = project.Attachement.Title,
                        MobMerchantMerchantId = CurrentMerchantId,
                        ContentType = project.Attachement.ContentType,
                        CreatedOn =  DateTime.Now,
                        //TaskId = project.Attachement.TaskId,
                        CreatedBy = adminId,
                        IsArchive = 0


                    }
                },
        
                
            };
            if (project.IsArchive == 1)
            {
                newProject.ArchiveDate = DateTime.Now;
            }
        
            await AppDbContext.PRJProject.AddAsync(newProject);
            await AppDbContext.SaveChangesAsync();


            ProjectHistoryDTO ProjectLog = new ProjectHistoryDTO 
            {
                Title = "Add Project",
                Category = "Project: " +project.ProjectName+" => has been created",
                ProjectId = AppDbContext.PRJProject.OrderByDescending(x=>x.Id).Select(c=>c.Id).FirstOrDefault(),
                CreatedBy = adminId
            };


            ProjectPublisher pub = new ProjectPublisher();
            ProjectSubscriber sub = new ProjectSubscriber(_projectHistory);
            sub.Subscribe(pub);
            pub.Notify(ProjectLog);


        }

        public async Task DeleteProject(int id)
        {
            var toBeDeleted = await AppDbContext.PRJProject
                                                 .Include(p=>p.Attachements)
                                                 .Include(p=>p.ProjectFollowers)
                                                 .Include(p=>p.Projects)
                                                 .Include(p=>p.Tasks) 
                                                 .ThenInclude(p=>p.TaskFollowers)                                                 
                                                .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                                                .FirstOrDefaultAsync();
            if (toBeDeleted == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);

            toBeDeleted.IsArchive = 1;
            //Archive all sub projects
            if (toBeDeleted.Projects.Where(x=>x.PRJProjectId == id) != null)
            {
                foreach (var item in toBeDeleted.Projects)
                {
                    item.IsArchive = 1;
                    await _task.ArchiveTasks(item.Tasks);
                    await _ProjectFollower.ArchiveProjectFollowers(item.ProjectFollowers);
                    await _adminProjectAttachements.ArchiveProjectAttachements(item.Attachements);
                }

            }
            await _task.ArchiveTasks(toBeDeleted.Tasks);
            await _ProjectFollower.ArchiveProjectFollowers(toBeDeleted.ProjectFollowers);
            await _adminProjectAttachements.ArchiveProjectAttachements(toBeDeleted.Attachements);
            
            AppDbContext.PRJProject.Update(toBeDeleted);
            await AppDbContext.SaveChangesAsync();

            ProjectHistoryDTO ProjectLog = new ProjectHistoryDTO
            {
                Title = "Delete Project",
                Category = "Project: " + toBeDeleted.Name + " => has been Deleted",
                ProjectId = id,
                //CreatedBy = adminId
            };


            ProjectPublisher pub = new ProjectPublisher();
            ProjectSubscriber sub = new ProjectSubscriber(_projectHistory);
            sub.Subscribe(pub);
            pub.Notify(ProjectLog);
        }

        public async Task<GetProjectDetailesInfo> GetProjectDetailes(int id)
        {
            
            
            
            var Result = await (from project in AppDbContext.PRJProject
                                .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.ProjectCategory)
                                .Include(x => x.ProjectStatus)
                                .Include(x=>x.Tasks).ThenInclude(x=>x.TaskStatus)
                                where project.MobMerchantMerchantId == CurrentMerchantId && project.Id == id  
                                && project.IsArchive == 0 
                            
                               
                                select new GetProjectDetailesInfo
                                {
                                     
                                    Id = project.Id,
                                    ProjectName = project.Name,
                                    Description = project.Description,
                                    ProjectStatus = project.ProjectStatus.Value,
                                    ProjectCategory = project.ProjectCategory.Value,
                                    StartDate = project.StartDate,
                                    EndDate = project.EndDate,
                                    CustomerName = project.CustomerName,
                                    ParentProject = project.PRJProjectId + "" ,
                                    Logo = JsonConvert.DeserializeObject<string>(project.Logo ?? "").WrapContentUrl(),
                                    CreatedOn = project.CreatedOn,
                                    CreatedBy = project.CreatedByAccount.FirstName + " " + project.CreatedByAccount.LastName,
                                    UpdatedOn = project.UpdatedOn,
                                    UpdatedBy = project.UpdatedByAccount.FirstName + " " + project.UpdatedByAccount.LastName,
                                    IsArchive = project.IsArchive,
                                   
                                    ArchiveDate = project.ArchiveDate,
                                    Tasks = _task.GetTasks(project.Id , new PRJTaskFilter()).Result,
                                    Followers = _ProjectFollower.GetProjectFollowerInfo(project.Id).Result,
                                    SubProjectsCount = AppDbContext.PRJProject.Where(x => x.PRJProjectId == project.Id).Count() , /*getSubProjectCount(project.Id)*/
                                    SubTasksCount  = AppDbContext.PRJTask.Where(x => x.ProjectId == project.Id).Count()  /*getSubProjectCount(project.Id)*/

                                }).FirstOrDefaultAsync();
            
            //get id for subproject
            var idSubProject = AppDbContext.PRJProject.Where(x => x.PRJProjectId == id).ToList();
            //end
            
            //get id task status finish
            var idTaskFinish = (from idTask in AppDbContext.PRJTaskStatus
                where idTask.Value == "finish"
                select idTask.Id ).First();
           //end
            var  TaskFinishCurrentProjectCount= AppDbContext.PRJTask.Where(x=>x.ProjectId == id && x.TaskStatusId == idTaskFinish).Count();
            var y = 0;
            var z = 0;
            
            foreach (var r in idSubProject)
            {
                y = y + AppDbContext.PRJTask.Where(x => x.ProjectId == r.Id).ToList().Count();
                z = z +AppDbContext.PRJTask.Where(x => x.ProjectId == r.Id && x.TaskStatusId == idTaskFinish).ToList().Count(); 

            }

            var taskFinish = z + TaskFinishCurrentProjectCount;
            var totalTask = y+ Result.SubTasksCount;
            Result.TaskFinish = taskFinish+"/"+totalTask  ;  
           
            
            if (Result == null)
            {
                return null;
            }
            Result.ProjectManager = Result.Followers.Count != 0 ?  Result.Followers.Where(x => x.Role == "Project Manager")
                                                                  .Select(a => a.FullName)
                                                                  .FirstOrDefault() : null;
            Result.Attachements =await _adminProjectAttachements.GetProjectAttachements(Result.Id);
            Result.ParentProject = Result.ParentProject == "" ? null : AppDbContext.PRJProject.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id ==Convert.ToInt32(Result.ParentProject)).Select(c => c.Name).FirstOrDefault();
            return Result;

        }       

        public async Task<List<GetProjectDTO>> GetProjects(PRJProjectFilter projectFilter )
        {
            var validFilter = new PRJProjectFilter(projectFilter.PageNumber, projectFilter.PageSize);

            var Result = await (from project in AppDbContext.PRJProject
                                .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.ProjectCategory)
                                .Include(x => x.ProjectStatus)
                                .Include(x=>x.ProjectFollowers)
                               

                               where project.MobMerchantMerchantId == CurrentMerchantId 
                               && project.IsArchive == 0  
                               
                                select new GetProjectDTO
                                {
                                    Id = project.Id,
                                    // ParentProjectID = project.PRJProjectId,
                                    ProjectName = project.Name,
                                    ProjectStatus = project.ProjectStatus.Value,
                                    StartDate = project.StartDate,
                                    EndDate = project.EndDate, 
                                    NumberLateDay =(int)(Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(project.EndDate)).TotalDays >0 ?(int)(Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(project.EndDate)).TotalDays : 0,
                                    CustomerName = project.CustomerName,
                                    CreatedOn = project.CreatedOn,
                                    CreatedBy = project.CreatedByAccount.FirstName + " " + project.CreatedByAccount.LastName,
                                    UpdatedOn = project.UpdatedOn,
                                    UpdatedBy = project.UpdatedByAccount.FirstName + " " + project.UpdatedByAccount.LastName,
                                    
                                    IsArchive = project.IsArchive,
                                    ArchiveDate = project.ArchiveDate,
                                    Followers = _ProjectFollower.GetProjectFollowerInfo(project.Id).Result,
                                    ProjectCategory = project.ProjectCategory.Value,
                                    SubProjectsCount = AppDbContext.PRJProject.Where(x => x.PRJProjectId == project.Id).Count(), /*getSubProjectCount(project.Id)*/

                                }).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                             .Take(validFilter.PageSize)
                             .ToListAsync();

            if (Result.Count == 0)
            {
                return null;
            }

            if (projectFilter.ClientName != null)
                Result = Result.Where(p => p.CustomerName == projectFilter.ClientName).ToList();
            if (projectFilter.State != null)
                Result = Result.Where(p => p.ProjectStatus == projectFilter.State).ToList();
            if (projectFilter.Category != null)
                Result = Result.Where(p => p.ProjectCategory == projectFilter.Category).ToList();

            return Result;
            //var result2 = (from project in AppDbContext.PRJProject.Include(c => c.CreatedByAccount).Include(c => c.UpdatedByAccount)
            //               where project.MobMerchantMerchantId == CurrentMerchantId
            //               select project).ToList();
            //return null ;

        }

        public async Task UpdateProject(int adminId ,int id, AddProjectDTO project)
        {
          
            var toBeUpdated = await AppDbContext.PRJProject
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = project.IsArchive;
            toBeUpdated.Name = project.ProjectName;
            toBeUpdated.ProjectCategoryId = project.ProjectCategoryId;
            toBeUpdated.ProjectStatusId = project.ProjectStatusId;
            toBeUpdated.Description = project.Description;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.EndDate = project.DueDate;
            toBeUpdated.StartDate = project.StartDate;
            toBeUpdated.Logo = JsonConvert.SerializeObject(project.Logo ?? "").WrapContentUrl();
            toBeUpdated.PRJProjectId = project.ParentProjectId;
            toBeUpdated.Label = project.Label;


            if (project.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJProject.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();

            ProjectHistoryDTO ProjectLog = new ProjectHistoryDTO
            {
                Title = "Delete Project",
                Category = "Project: " + toBeUpdated.Name + " => has been Updated",
                ProjectId = id,
                CreatedBy = adminId
            };


            ProjectPublisher pub = new ProjectPublisher();
            ProjectSubscriber sub = new ProjectSubscriber(_projectHistory);
            sub.Subscribe(pub);
            pub.Notify(ProjectLog);
        }

        public async Task<AddProjectDropDownData> GetProjectDropDownsData()
        {
            var result = new AddProjectDropDownData();

            var projects = await GetProjects(new PRJProjectFilter());
            var categories =await _category.GetProjectCategories();
            var states =await _status.GetProjectStatus();

            result.Categories = categories == null ? null :categories.Select(x => x.Value).ToList();
            result.ParentProjects = projects == null ? null : (from project in projects select new AddProjectDropDownDataDTO(){Name =  project.ProjectName,Id= project.Id}).ToList();
            result.States = states == null ? null : states.Select(x => x.Value).ToList();      

            return result;

        }

        public async Task<List<GetTreeViewOfProjectsDTO>> GetTreeViewOfProjects(PRJProjectFilter projectFilter)
        {
            var validFilter = new PaginationFilterDTO(projectFilter.PageNumber, projectFilter.PageSize);

            var Result = await (from project in AppDbContext.PRJProject
                                       .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.ProjectCategory)
                                .Include(x => x.ProjectStatus)
                                where project.MobMerchantMerchantId == CurrentMerchantId && project.IsArchive == 0                                   
                               
                                select new GetTreeViewOfProjectsDTO
                                {
                                    ProjectId = project.Id,
                                    ProjectName = project.Name,
                                    ProjectStatus = project.ProjectStatus.Value,
                                    CustomerName = project.CustomerName,
                                    ProjectCategory = project.ProjectCategory.Value

                                }).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                  .Take(validFilter.PageSize)
                                  .ToListAsync();
            if (Result.Count == 0)
            {
                return null;
            }
            if (projectFilter.ClientName != null)
                Result = Result.Where(p => p.CustomerName == projectFilter.ClientName).ToList();
            if (projectFilter.State != null)
                Result = Result.Where(p => p.ProjectStatus == projectFilter.State).ToList();
            if (projectFilter.Category != null)
                Result = Result.Where(p => p.ProjectCategory == projectFilter.Category).ToList();
            foreach (var item in Result)
            {
                item.SubProjects = GetSubProjectsForProject(item.ProjectId, projectFilter).Result;
            }

            return Result;

        }

        public  async Task<List<SubProjectsDTO>> GetSubProjectsForProject(int projectId ,PRJProjectFilter projectFilter)
        {
            var validFilter = new PaginationFilterDTO(projectFilter.PageNumber, projectFilter.PageSize);

            var Result = await (from project in AppDbContext.PRJProject
                                       .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.ProjectCategory)
                                .Include(x => x.ProjectStatus)
                                where project.MobMerchantMerchantId == CurrentMerchantId 
                                && project.IsArchive ==0
                                && project.PRJProjectId == projectId
                               
                                select new SubProjectsDTO
                                {
                                    SubProjectId = project.Id,
                                    ProjectName = project.Name,
                                    ProjectStatus = project.ProjectStatus.Value,
                                    CustomerName = project.CustomerName,
                                    ProjectCategory = project.ProjectCategory.Value
                                }).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                             .Take(validFilter.PageSize)
                             .ToListAsync();
            if (Result.Count == 0)
            {
                return null;
            }
            if (projectFilter.ClientName != null)
                Result = Result.Where(p => p.CustomerName == projectFilter.ClientName).ToList();
            if (projectFilter.State != null)
                Result = Result.Where(p => p.ProjectStatus == projectFilter.State).ToList();
            if (projectFilter.Category != null)
                Result = Result.Where(p => p.ProjectCategory == projectFilter.Category).ToList();

            return Result;

        }
    }
}

