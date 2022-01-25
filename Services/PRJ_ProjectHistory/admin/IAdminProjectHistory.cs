using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_ProjectHistoryDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_ProjectHistory.admin
{
    public interface IAdminProjectHistory
    {
        Task<List<ProjectHistoryDTO>> GetProjectLogs(int projectId);
        Task AddProjectLog( ProjectHistoryDTO project);
    }


}
