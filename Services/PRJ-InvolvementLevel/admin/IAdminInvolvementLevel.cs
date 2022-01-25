using Meta.IntroApp.DTOs.PRJ_InvolvementLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_InvolvementLevel.admin
{
   public interface IAdminInvolvementLevel
    {
        Task<List<GetInvolvementLevelDTO>> GetLevels();

        Task AddLevel(int clientID,AddInvolvementLevelDTO level);

        Task UpdateLevel(int clientID, int id, AddInvolvementLevelDTO level);

        Task DeleteLevel(int id);
    }
}
