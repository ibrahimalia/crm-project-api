using Meta.IntroApp.DTOs.PRJ_TaskStatusDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskStatus
{
   public interface IAdminTaskStatus
    {
        Task<List<GetTaskStatusDTO>> GetTaskStatus();

        Task AddTaskStatus(int admin, AddTaskStatusDTO model);

        Task UpdateTaskStatus(int admin, int id, AddTaskStatusDTO model);

        Task DeleteTaskStatus(int id);
    }
}
