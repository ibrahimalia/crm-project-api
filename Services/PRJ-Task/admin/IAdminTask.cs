using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.DTOs.PRJ_Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Task.admin
{
   public interface IAdminTask
    {
        Task<List<GetTasksDTO>> GetTasks(int projectId, PRJTaskFilter TaskFilter);
        Task<List<GetTasksDTO>> NewGetTasks(int projectId, PRJTaskFilter TaskFilter);

        Task<GetTaskDTO> GetTaskDetailes(int id);
        Task<TaskDropDownsDTO> GetTaskDropDownsData();

        Task AddTask(int adminId, AddTaskDTO project);

        Task UpdateTask(int adminId, int id, AddTaskDTO project);

        Task ArchiveTask(int id);
        Task ArchiveTasks(ICollection<PRJTask> tasks);

    }
}
