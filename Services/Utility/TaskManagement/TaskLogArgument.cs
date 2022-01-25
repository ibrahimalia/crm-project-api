using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;

namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class TaskLogArgument : EventArgs
    {
        public TaskHistoryDTO TaskLog { get; set; }     

        public TaskLogArgument(TaskHistoryDTO TaskLog)
        {
            this.TaskLog = TaskLog;
          
        }
    }
}
