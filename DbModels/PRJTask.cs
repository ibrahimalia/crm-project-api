using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJTask
    {
        public PRJTask()
        {
            TasktHistories = new HashSet<PRJTaskHistory>();
            Attachements = new HashSet<PRJAttachements>();
            TimeSheets = new HashSet<PRJTimeSheet>();
            Tasks = new HashSet<PRJTask>();
        }
        public int Id { get; set; }
        [ForeignKey("PRJProject")]
        public int ProjectId { get; set; }
        [ForeignKey("PRJTask")]
        public int? PRJTaskId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DuetDate { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        [ForeignKey("PRJTaskStatus")]
        public int? TaskStatusId { get; set; }

        [ForeignKey("PRJProjectRole")]
        public int? ProjectRoleId { get; set; }
     
        public int? OwnerId { get; set; }
        public int IsMajor { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public string Label { get; set; }

        public virtual PRJProject Project { get; set; }
        public virtual PRJProjectRole ProjectRole { get; set; }
        public virtual PRJTaskStatus TaskStatus { get; set; }
        public virtual ICollection<PRJTask> Tasks{ get; set; }
        public virtual ICollection<PRJTaskHistory> TasktHistories { get; set; }
        public virtual ICollection<PRJAttachements> Attachements { get; set; }
        public virtual ICollection<PRJTaskFollower> TaskFollowers { get; set; }
        public virtual ICollection<PRJTimeSheet> TimeSheets { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }


        [ForeignKey("OwnerId")]
        public virtual PRJContacts Owner { get; set; }
    }
}
