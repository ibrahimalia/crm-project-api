using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TimeSheet;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TimeSheet.Admin
{
    public class AdminTimeSheetService : BaseService , IAdminTimesheet
    {
        public AdminTimeSheetService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
           
        }

        public async Task AddTimeSheet(long userId, AddTimeSheetDTO model)
        {
            var newTimeSheet = new PRJTimeSheet
            {
                Duration = model.Duration,               
                MerchantID = CurrentMerchantId,
                Notes = model.Notes,
                TaskId = model.TaskId,              
                UserId = userId,
                Day = model.Day,
                FromHour = model.FromHour,
                ToHour = model.ToHour,
                FromMinute = model.FromMinute,
                ToMinute = model.ToMinute
                
            };
            await AppDbContext.PRJTimeSheet.AddAsync(newTimeSheet);
            await AppDbContext.SaveChangesAsync();

        }

        public async Task<GetTimeSheetDTO> GetTimeSheetDetailes(int id)
        {
            var result = await AppDbContext.PRJTimeSheet
                                     .Include(x => x.Task)
                                     .Include(x => x.User).Where(x => x.MerchantID == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();

            if (result == null)
            {
                return null;
            }
           
            return new GetTimeSheetDTO
            {
                Id = result.Id,
              Duration= result.Duration == null ? 
                       (((result.ToHour - result.FromHour)*60)+(result.ToMinute - result.FromMinute))/60 + " "+"Hour" +
                       (((result.ToHour - result.FromHour) * 60) + (result.ToMinute - result.FromMinute)) % 60 + " " + "Minutes"
                       :result.Duration+"",
                Notes = result.Notes,
                TaskName = result.Task.Name,
               Day = result.Day.Value.GetDate(),
                UserName = result.User.FirstName + " " + result.User.LastName
            };

        }

        public async Task<List<GetTimeSheetDTO>> GetTimeSheets(long? userId)
        {
            var result = await AppDbContext.PRJTimeSheet
                                       .Include(x => x.Task)
                                       .Include(x => x.User).Where(x => x.MerchantID == CurrentMerchantId && x.UserId == userId).ToListAsync();
            return result?.ConvertAll(one => new GetTimeSheetDTO
            {
                Id = one.Id,
                Duration = one.Duration == null ?
                       (((one.ToHour - one.FromHour) * 60) + (one.ToMinute - one.FromMinute)) / 60 + " " + "Hour" +
                       (((one.ToHour - one.FromHour) * 60) + (one.ToMinute - one.FromMinute)) % 60 + " " + "Minutes"
                       : one.Duration + "",
                Notes = one.Notes,
                TaskName = one.Task.Name,
                Day = one.Day.Value.GetDate(),
                UserName = one.User.FirstName + " " + one.User.LastName
            }).ToList();
        }

        public async Task<List<GetTimeSheetDTO>> GetTimeSheets()
        {
            var result = await AppDbContext.PRJTimeSheet
                                    .Include(x => x.Task)
                                    .Include(x => x.User).Where(x => x.MerchantID == CurrentMerchantId ).ToListAsync();
            return result?.ConvertAll(one => new GetTimeSheetDTO
            {
                Id = one.Id,
                Duration = one.Duration == null ?
                       (((one.ToHour - one.FromHour) * 60) + (one.ToMinute - one.FromMinute)) / 60 + " " + "Hour" +
                       (((one.ToHour - one.FromHour) * 60) + (one.ToMinute - one.FromMinute)) % 60 + " " + "Minutes"
                       : one.Duration + "",
                Notes = one.Notes,
                TaskName = one.Task.Name,
                Day = one.Day.Value.GetDate(),
                UserName = one.User.FirstName + " " + one.User.LastName
            }).ToList();
        }

        public async Task UpdateTimeSheet(int id, AddTimeSheetDTO model)
        {
           var toBeUpdated = await AppDbContext.PRJTimeSheet
                                    .Where(x => x.MerchantID == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Duration = model.Duration;
            toBeUpdated.FromHour = model.FromHour;
            toBeUpdated.ToHour = model.ToHour;
            toBeUpdated.MerchantID = CurrentMerchantId;
            toBeUpdated.Notes = model.Notes;
            toBeUpdated.TaskId = model.TaskId;
            toBeUpdated.ToMinute = model.ToMinute;

            AppDbContext.PRJTimeSheet.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();

        }
    }
}
