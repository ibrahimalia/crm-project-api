using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJProjectHistory
    {
        public int Id { get; set; }
        [ForeignKey("PRJProject")]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("PRJProjectFollowers")]
        //public int ProjectFollowerId { get; set; }
        public DateTime? HistoryDate { get; set; }
        public string Category { get; set; }
        //public int ProjectFollowerId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public string Color { get; set; }
        public string EventType { get; set; }

        public virtual PRJProjectFollowers ProjectFollower { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }
    }
}
