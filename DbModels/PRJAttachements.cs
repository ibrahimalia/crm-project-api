using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJAttachements
    {
        public int Id { get; set; }
        [ForeignKey("PRJProject")]
        public int ProjectId { get; set; }
        [ForeignKey("PRJTask")]
        public int? TaskId { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }


        public virtual PRJProject Project { get; set; }
        public virtual PRJTask Task { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }
    }
}
