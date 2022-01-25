using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskHistory
{
    public class AdminTaskHistoryService : BaseService, IAdminTaskHistory
    {
        public AdminTaskHistoryService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {

        }

        public async Task AddTaskLog(TaskHistoryDTO log)
        {
            var newTaskLog = new PRJTaskHistory
            {
                Category = log.Category,
                Title = log.Title,
                PRJTaskId = log.TaskId
            };

           await AppDbContext.PRJTaskHistory.AddAsync(newTaskLog);
            await AppDbContext.SaveChangesAsync() ;
        }

        public async Task<List<TaskHistoryDTO>> GetTaskLogs(int taskId)
        {
            var TaskLogs = await AppDbContext.PRJTaskHistory.Where(x => x.PRJTaskId == taskId).ToListAsync();
            return TaskLogs?.ConvertAll(log => new TaskHistoryDTO
            {
                TaskId = log.PRJTaskId,
                Category = log.Category,
                Title = log.Title,

            }).ToList();
        }
    }
}
