using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJProject
    {
        public PRJProject()
        {
            Projects = new HashSet<PRJProject>();
          
            ProjectFollowers = new HashSet<PRJProjectFollowers>();
            Tasks = new HashSet<PRJTask>();
            Attachements = new HashSet<PRJAttachements>();
        }

        public int Id { get; set; }

        [ForeignKey("PRkProject")]
        public int? PRJProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("PRJProjectStatus")]
        public int? ProjectStatusId {get; set;}
        public string CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string Logo { get; set; }

        [ForeignKey("PRJProjectCategory")]
        public int? ProjectCategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public string Label { get; set; }

        public virtual ICollection<PRJProject> Projects { get; set; }

        public virtual ICollection<PRJProjectFollowers> ProjectFollowers { get; set; }
        public virtual ICollection<PRJAttachements> Attachements { get; set; }
        public virtual ICollection<PRJTask> Tasks { get; set; }
        public virtual PRJProjectCategory ProjectCategory { get; set; }
        public virtual PRJProjectStatus ProjectStatus { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }


    }
}
