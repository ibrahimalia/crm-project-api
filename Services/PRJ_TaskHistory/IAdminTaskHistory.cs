using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskHistory
{
   public interface IAdminTaskHistory
    {
        Task<List<TaskHistoryDTO>> GetTaskLogs(int projectId);
        Task AddTaskLog(TaskHistoryDTO project);
    }
}
