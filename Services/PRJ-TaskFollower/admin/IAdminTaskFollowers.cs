using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskFollower
{
  public  interface IAdminTaskFollowers
    {
        Task<List<GetTaskFollowersDTO>> GetTaskFollowers(int taskID);
        Task<GetTaskFollowersDTO> GetTaskFollowerDetailes(int id);

        Task AddTaskFollower(int adminId, AddTaskFollowersDTO project);

        Task UpdateTaskFollower(int adminId, int id, AddTaskFollowersDTO project);

        Task ArchiveTaskFollower(int id);
        Task ArchiveTaskFollowers(ICollection<PRJTaskFollower> taskFollowers);
        Task<List<GetTaskFollowersInfoDTO>> GetTaskFollowersInfo(int taskID);
    }
}
