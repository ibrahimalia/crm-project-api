using Meta.IntroApp.DTOs.PRJ_TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TimeSheet.Admin
{
   public interface IAdminTimesheet
    {
        Task AddTimeSheet(long userId , AddTimeSheetDTO model);
        Task<List<GetTimeSheetDTO>> GetTimeSheets(long? userId);
        Task<List<GetTimeSheetDTO>> GetTimeSheets();
        Task<GetTimeSheetDTO> GetTimeSheetDetailes(int id);
        Task UpdateTimeSheet(int id , AddTimeSheetDTO model );
    }
}
