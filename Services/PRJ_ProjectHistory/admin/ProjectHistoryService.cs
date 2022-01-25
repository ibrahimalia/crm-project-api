using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectHistory.admin
{
    public class ProjectHistoryService : BaseService, IAdminProjectHistory
    {
        public ProjectHistoryService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {

        }

        public async Task AddProjectLog(ProjectHistoryDTO project)
        {
            var newLog = new PRJProjectHistory
            {
                Title = project.Title,
                Category = project.Category,
                ProjectId = project.ProjectId,
                MobMerchantMerchantId = CurrentMerchantId,
                CreatedBy = project.CreatedBy,
                
              
            };
           await AppDbContext.PRJProjectHistory.AddAsync(newLog);
            await AppDbContext.SaveChangesAsync();

        }

        public async Task<List<ProjectHistoryDTO>> GetProjectLogs(int projectId)
        {
            var projectLogs =await AppDbContext.PRJProjectHistory.Where(x=>x.ProjectId == projectId).ToListAsync();
            return projectLogs?.ConvertAll(log => new ProjectHistoryDTO
            {
               ProjectId = log.ProjectId,               
                Category = log.Category,
                Title = log.Title,
                
            }).ToList();
        }
    }
}
