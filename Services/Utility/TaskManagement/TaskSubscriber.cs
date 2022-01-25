using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using Meta.IntroApp.Services.PRJ_TaskHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class TaskSubscriber 
    {
        private readonly IAdminTaskHistory _TaskHistory;

        public TaskSubscriber(IAdminTaskHistory TaskHistory) 
        {
            _TaskHistory = TaskHistory;
        }
        public void Subscribe(TaskPublisher pub)
        {
            pub.Arguments += AddLog;
        }

        public void UnSubscribe(TaskPublisher pub)
        {
            pub.Arguments -= AddLog;
        }

        public void AddLog(Object sender, TaskLogArgument argument)
        {
            var newLog = new TaskHistoryDTO
            {
                Title = argument.TaskLog.Title,
                Category = argument.TaskLog.Category,
               TaskId = argument.TaskLog.TaskId,
               CreatedOn = argument.TaskLog.CreatedOn
                
            };

            _TaskHistory.AddTaskLog(newLog);
      
        }


    }
}
