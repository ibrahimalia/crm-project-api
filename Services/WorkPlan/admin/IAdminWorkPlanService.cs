using Meta.IntroApp.DTOs.WorkPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminWorkPlanService
    {
        Task<WorkPlanDTO> GetWorkPlanDetailes(int? workPlanId);
        Task<List<WorkPlanDTO>> GetAllWorkPlanDetailes();

        Task AddWorkPlan(AddWorkPlanDTO news);

        Task UpdateWorkPlan(int worlPlanID, AddWorkPlanDTO news);

        Task DeleteWorkPlan(int newsId);
      
    }
}