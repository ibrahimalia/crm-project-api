using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;

namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class ProjectLogArgument : EventArgs
    {
        public ProjectHistoryDTO ProjectLog { get; set; }     

        public ProjectLogArgument(ProjectHistoryDTO ProjectLog)
        {
            this.ProjectLog = ProjectLog;
          
        }
    }
}
