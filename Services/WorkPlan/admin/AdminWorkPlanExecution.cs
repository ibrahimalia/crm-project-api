using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs.WorkPlan;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminWorkPlanExecution : BaseService, IAdminWorkPlanService
    {
        public AdminWorkPlanExecution(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }

        public async Task AddWorkPlan(AddWorkPlanDTO model)
        {
            MobWorkPlan Plan = new MobWorkPlan
            {
                FirstWorkTimeEnd = DateTime.Parse(model.FirstWorkTimeEnd, System.Globalization.CultureInfo.CurrentCulture),
                FirstWorkTimeStart = DateTime.Parse(model.FirstWorkTimeStart, System.Globalization.CultureInfo.CurrentCulture),
                SecondWorkTimeStart = DateTime.Parse(model.SecondWorkTimeStart, System.Globalization.CultureInfo.CurrentCulture),
                SecondWorkTimeEnd = DateTime.Parse(model.SecondWorkTimeEnd, System.Globalization.CultureInfo.CurrentCulture),
                Notes = model.Notes,
                PlanName = model.PlanName,
                FromDay = Convert.ToDateTime(model.FromDay),
                ToDay = Convert.ToDateTime(model.ToDay)
            };

            Plan.MerchantId = CurrentMerchantId;
            Plan.BranchId = CurrentBranchId;
            await AppDbContext.WorkPlans.AddAsync(Plan);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteWorkPlan(int planID)
        {
            var del = AppDbContext.WorkPlans.Where(p => p.MerchantId == CurrentMerchantId
                                                     && p.Id == planID
                                                     && (!CurrentBranchId.HasValue || p.BranchId == CurrentBranchId))
                                                      .FirstOrDefault();

            if (del == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);
            AppDbContext.WorkPlans.Remove(del);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<List<WorkPlanDTO>> GetAllWorkPlanDetailes()
        {
            var Result = await AppDbContext.WorkPlans.Where(o => (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId)
                                                             && o.MerchantId == CurrentMerchantId)
                                                           .ToListAsync();
            if (Result == null)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }
            return Result.ConvertAll(plans => new WorkPlanDTO
            {
                Id = plans.Id,
                PlanName = plans.PlanName,
                ToDay = (plans.ToDay).Value.ToString("yyyy-MM-dd"),
                FromDay = (plans.FromDay).Value.ToString("yyyy-MM-dd"),
                FirstWorkTimeEnd = (plans.FirstWorkTimeEnd).Value.ToString("HH:mm"),
                FirstWorkTimeStart = (plans.FirstWorkTimeStart).Value.ToString("HH:mm"),
                SecondWorkTimeEnd = (plans.SecondWorkTimeEnd).Value.ToString("HH:mm"),
                SecondWorkTimeStart = (plans.SecondWorkTimeStart).Value.ToString("HH:mm"),
                Notes = plans.Notes,
            });
            // string x = subResult.PublishingDate.Value.ToString("yyyy-MM-dd");
        
        }

        public async Task<WorkPlanDTO> GetWorkPlanDetailes(int? workPlanId)
        {
            MobWorkPlan subResult = await AppDbContext.WorkPlans.Where(o => (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId)
                                                               && o.MerchantId == CurrentMerchantId && o.Id == workPlanId)
                                                             .FirstOrDefaultAsync();
            if (subResult == null)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }
            WorkPlanDTO result = new WorkPlanDTO
            {
                Id = subResult.Id,
                PlanName = subResult.PlanName,
                ToDay = (subResult.ToDay).Value.ToString("yyyy-MM-dd"),
                FromDay = (subResult.FromDay).Value.ToString("yyyy-MM-dd"),
                FirstWorkTimeEnd = (subResult.FirstWorkTimeEnd).Value.ToString("HH:mm"),
                FirstWorkTimeStart = (subResult.FirstWorkTimeStart).Value.ToString("HH:mm"),
                SecondWorkTimeEnd = (subResult.SecondWorkTimeEnd).Value.ToString("HH:mm"),
                SecondWorkTimeStart = (subResult.SecondWorkTimeStart).Value.ToString("HH:mm"),
                Notes = subResult.Notes,
            };
            // string x = subResult.PublishingDate.Value.ToString("yyyy-MM-dd");
            return result;
        }

        public async Task UpdateWorkPlan(int worklPlanID, AddWorkPlanDTO newworkPlan)
        {
            MobWorkPlan subResult = await AppDbContext.WorkPlans.Where(o => (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId)
                                                           && o.MerchantId == CurrentMerchantId && o.Id == worklPlanID)
                                                         .FirstOrDefaultAsync();
            if (subResult != null)
            {
                subResult.PlanName = newworkPlan.PlanName;
                subResult.ToDay = Convert.ToDateTime(newworkPlan.ToDay);
                subResult.FromDay = Convert.ToDateTime(newworkPlan.FromDay);
                subResult.FirstWorkTimeEnd = DateTime.Parse(newworkPlan.FirstWorkTimeEnd);
                subResult.FirstWorkTimeStart = DateTime.Parse(newworkPlan.FirstWorkTimeStart);
                subResult.SecondWorkTimeEnd = DateTime.Parse(newworkPlan.SecondWorkTimeEnd);
                subResult.SecondWorkTimeStart = DateTime.Parse(newworkPlan.SecondWorkTimeStart);

                AppDbContext.WorkPlans.Update(subResult);
                await AppDbContext.SaveChangesAsync();
            }
        }
    }
}