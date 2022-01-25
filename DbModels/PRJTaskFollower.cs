using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJTaskFollower
    {
        public PRJTaskFollower()
        {
            TaskHistories = new HashSet<PRJTaskHistory>();
           
        }
        public int Id { get; set; }
        [ForeignKey("PRJTask")]

        public int PRJTaskId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("PRJContacts")]
        public int ContactsId { get; set; }

        [ForeignKey("PRJProjectRole")]
        public int? ProjectRoleId { get; set; }

        [ForeignKey("PRJInvolvementLevel")]
        public int? TaskLevelId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }


        public virtual PRJContacts Contacts { get; set; }
        public virtual PRJProject Project { get; set; }
        public virtual PRJProjectRole ProjectRole { get; set; }
        public virtual PRJInvolvementLevel TaskLevel { get; set; }
        public virtual ICollection<PRJTaskHistory> TaskHistories { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }

    }
}
