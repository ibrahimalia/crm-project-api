using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class ProjectPublisher
    {
        public string Name { get; set; }

        public event EventHandler<ProjectLogArgument> Arguments;

        public void Notify(ProjectHistoryDTO ProjectLog)
        {
            ProjectLogArgument argument = new ProjectLogArgument(ProjectLog);

            if (Arguments != null)
            {
                Arguments(this, argument);
            }
        }
    }
}
