
using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Attachement.client
{
   public interface IAdminProjectFollower
    {
        Task<List<GetProjectFollowerDTO>> GetProjectFollower(int projectID);
        Task<List<GetProjectManagerInfo>> GetProjectManger(int projectID);

        Task AddProjectFollower(int adminID, ADDProjectFollowerDTO model);

        Task UpdateProjectFollower(int adminID, int ProjectFollowerId, ADDProjectFollowerDTO model);
        Task<List<GetProjectFollowerInfoDTO>> GetProjectFollowerInfo(int projectID);
        Task ArchiveProjectFollower(int id);
        Task ArchiveProjectFollowers(ICollection<PRJProjectFollowers> projectFollowers);
    }
}
