using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_ProjectStatusDTO
{
    public class GetProjectStatusDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
    }
}
