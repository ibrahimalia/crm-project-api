using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meta.IntroApp.Services.Utility.ProjectManagement
{
    public class ProjectSubscriber 
    {
        private readonly IAdminProjectHistory _projectHistory;

        public ProjectSubscriber(IAdminProjectHistory projectHistory) 
        {
            _projectHistory = projectHistory;
        }
        public void Subscribe(ProjectPublisher pub)
        {
            pub.Arguments += AddLog;
        }

        public void UnSubscribe(ProjectPublisher pub)
        {
            pub.Arguments -= AddLog;
        }

        public void AddLog(Object sender, ProjectLogArgument argument)
        {
            var newLog = new ProjectHistoryDTO 
            {
                Title = argument.ProjectLog.Title,
                Category = argument.ProjectLog.Category,
                ProjectId = argument.ProjectLog.ProjectId,
                
            };

            _projectHistory.AddProjectLog(newLog);
      
        }


    }
}
