using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.DTOs.PRJ_TaskHistoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class TaskPublisher
    {
        public string Name { get; set; }

        public event EventHandler<TaskLogArgument> Arguments;

        public void Notify(TaskHistoryDTO TaskLog)
        {
            TaskLogArgument argument = new TaskLogArgument(TaskLog);

            if (Arguments != null)
            {
                Arguments(this, argument);
            }
        }
    }
}
