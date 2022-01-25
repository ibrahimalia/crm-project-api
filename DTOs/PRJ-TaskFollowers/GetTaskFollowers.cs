using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_TaskFollowers
{
    public class GetTaskFollowersDTO
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string ProjectName { get; set; }
        public string FullName { get; set; }
        public string ProjectRole { get; set; }
        public string TaskLevel { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
    }
    public class GetTaskFollowersInfoDTO
    {
        public int Id { get; set; }
        //public string ParentTask { get; set; }
        //public string ParentProject { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string ProjectRole { get; set; }
        public string TaskLevel { get; set; }
      
    }
    
}
