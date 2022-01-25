using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobBranch
    {
        public MobBranch()
        {
            MobAppointments = new HashSet<MobAppointment>();
            MobContacts = new HashSet<MobContact>();
            MobGlobalThemes = new HashSet<MobGlobalTheme>();
            MobImages = new HashSet<MobImage>();
            MobNews = new HashSet<MobNews>();
            MobOurTeams = new HashSet<MobOurTeam>();
            MobProjects = new HashSet<MobProject>();
            MobServices = new HashSet<MobService>();
            MobWorkPlans = new HashSet<MobWorkPlan>();
        }

        public int BranchesId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string MerchantId { get; set; }
        public int? IsMain { get; set; }
        public int? IsActive { get; set; }

        public virtual MobMerchant Merchant { get; set; }
        public virtual ICollection<MobAppointment> MobAppointments { get; set; }
        public virtual ICollection<MobContact> MobContacts { get; set; }
        public virtual ICollection<MobGlobalTheme> MobGlobalThemes { get; set; }
        public virtual ICollection<MobImage> MobImages { get; set; }
        public virtual ICollection<MobNews> MobNews { get; set; }
        public virtual ICollection<MobOurTeam> MobOurTeams { get; set; }
        public virtual ICollection<MobProject> MobProjects { get; set; }
        public virtual ICollection<MobService> MobServices { get; set; }
        public virtual ICollection<MobWorkPlan> MobWorkPlans { get; set; }
    }
}