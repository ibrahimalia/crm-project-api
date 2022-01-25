using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_ProjectFollower
{
    public class GetProjectFollowerDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Image { get; set; }
        public string ContactName { get; set; }
        public string ProjectRole { get; set; }
        public string ProjectLevel { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
    
    }

    public class GetProjectManagerInfo
    {
        public string ContactName { get; set; }
        public string Image { get; set; } 
    }
    public class GetProjectFollowerInfoDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string InvolvementLevel { get; set; }
        public string Role { get; set; }
    }
}
