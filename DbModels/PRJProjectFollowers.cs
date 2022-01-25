using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJProjectFollowers
    {
        public PRJProjectFollowers()
        {
            ProjectHistories = new HashSet<PRJProjectHistory>();
        }
        public int Id { get; set; }
        [ForeignKey("PRJProject")]
        public int ProjectId { get; set; }
        public int ContactsId { get; set; }

        [ForeignKey("PRJInvolvementLevel")]
        public int? ProjectLevelId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public int? PRJProjectRole { get; set; }


        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }

        [ForeignKey("ContactsId")]
        public virtual PRJContacts Contact { get; set; }

        [ForeignKey("PRJProjectRole")]
        public virtual PRJProjectRole ProjectRole { get; set; }
        public virtual PRJProject Project { get; set; }
        public virtual PRJInvolvementLevel ProjectLevel { get; set; }
        public virtual ICollection<PRJProjectHistory> ProjectHistories { get; set; }
    }
}
