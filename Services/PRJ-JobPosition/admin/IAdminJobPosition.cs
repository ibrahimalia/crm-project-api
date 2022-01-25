using Meta.IntroApp.DTOs.PRJ_jobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_JobPosition.admin
{
   public interface IAdminJobPosition
    {
        Task<List<GetJobPositions>> GetJobPositions();

        Task AddJobPosition(int AdminID ,AddJobPositionDTO jobPosition);

        Task UpdateJobPosition(int AdminID, int id, AddJobPositionDTO jobPosition);

        Task DeleteJobPosition(int id);
    }
}
