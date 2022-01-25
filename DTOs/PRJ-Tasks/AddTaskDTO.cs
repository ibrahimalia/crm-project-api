using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Tasks
{
    public class AddTaskDTO
    {
        public int ProjectId { get; set; }
        public int? PRJTaskId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DuetDate { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public int TaskStatusId { get; set; }
        public int ProjectRoleId { get; set; }
        public int? OwnerId { get; set; }
        public int IsMajor { get; set; }
        public string Description { get; set; }
        public int? IsArchive { get; set; }
        public string Label{ get; set; }
      
    }
}
