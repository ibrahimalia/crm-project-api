using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJTaskHistory
    {

        public int Id { get; set; }
        public int PRJTaskId { get; set; }
        public string Title { get; set; }
        public int PRJTaskFollowerId { get; set; }
        public string Description { get; set; }
        public DateTime? HistoryDate { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public string Color { get; set; }
        public string EventType { get; set; }


        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }
    }
}
