using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_TimeSheet
{
    public class AddTimeSheetDTO
    {
        //public long? UserId { get; set; }
        public DateTime? Day { get; set; }
        public int? FromHour { get; set; }
        public int? ToHour { get; set; }
        public int? FromMinute { get; set; }
        public int? ToMinute { get; set; }
        public int? Duration { get; set; }
        public int TaskId { get; set; }
        public string Notes { get; set; }
    }   
    public class GetTimeSheetDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string TaskName { get; set; }
        public string Day { get; set; }
        //public int? FromHour { get; set; }
        //public int? ToHour { get; set; }
        //public int? FromMinute { get; set; }
        //public int? ToMinute { get; set; }
        public string Duration { get; set; }
      
        public string Notes { get; set; }
    }
}
