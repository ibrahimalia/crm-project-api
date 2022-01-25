using Meta.IntroApp.DbModels;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobMerchant
    {
        public MobMerchant()
        {
            
            Accounts = new HashSet<Account>();
            MobAbouts = new HashSet<MobAbout>();
            MobAppointments = new HashSet<MobAppointment>();
            MobBranches = new HashSet<MobBranch>();
            MobContacts = new HashSet<MobContact>();
            MobGlobalThemes = new HashSet<MobGlobalTheme>();
            MobNews = new HashSet<MobNews>();
            MobOurTeams = new HashSet<MobOurTeam>();
            MobProjects = new HashSet<MobProject>();
            MobServices = new HashSet<MobService>();
            MobWorkPlans = new HashSet<MobWorkPlan>();
            MobFeedBacks = new HashSet<MobFeedBack>();
            MobRequests = new HashSet<MobRequest>();
           

            //*******Project Management*****
            
            AddressType = new HashSet<PRJAddressType>();
            Attachements = new HashSet<PRJAttachements>();
            Contacts = new HashSet<PRJContacts>();
            InvolvementLevel = new HashSet<PRJInvolvementLevel>();
            JobPosition = new HashSet<PRJJobPosition>();
            Project = new HashSet<PRJProject>();
            ProjectCategory = new HashSet<PRJProjectCategory>();
            ProjectFollowers = new HashSet<PRJProjectFollowers>();
            ProjectHistory = new HashSet<PRJProjectHistory>();
            ProjectRole = new HashSet<PRJProjectRole>();
            ProjectStatus = new HashSet<PRJProjectStatus>();
            Tag = new HashSet<PRJTAG>();
            Task = new HashSet<PRJTask>();
            TaskFollower = new HashSet<PRJTaskFollower>();
            TaskHistory = new HashSet<PRJTaskHistory>();
            TaskStatus = new HashSet<PRJTaskStatus>();
            TimeSheets = new HashSet<PRJTimeSheet>();

        }

        public string MerchantId { get; set; }
        public string MerchantName { get; set;}
        public int Interval{ get; set; }
        public string Email { get; set; }

        public virtual ICollection<MobRequest> MobRequests { get; set; }
        public virtual ICollection<MobFeedBack> MobFeedBacks { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<MobAbout> MobAbouts { get; set; }
        public virtual ICollection<MobAppointment> MobAppointments { get; set; }
        public virtual ICollection<MobBranch> MobBranches { get; set; }
        public virtual ICollection<MobContact> MobContacts { get; set; }
        public virtual ICollection<MobGlobalTheme> MobGlobalThemes { get; set; }
        public virtual ICollection<MobNews> MobNews { get; set; }
        public virtual ICollection<MobOurTeam> MobOurTeams { get; set; }
        public virtual ICollection<MobProject> MobProjects { get; set; }
        public virtual ICollection<MobService> MobServices { get; set; }
        public virtual ICollection<MobWorkPlan> MobWorkPlans { get; set; }
        
        //************ Project Management ************
        
        public virtual ICollection<PRJAddressType> AddressType { get; set; }
        public virtual ICollection<PRJAttachements> Attachements { get; set; }
        public virtual ICollection<PRJContacts> Contacts { get; set; }
        public virtual ICollection<PRJInvolvementLevel> InvolvementLevel { get; set; }
        public virtual ICollection<PRJJobPosition> JobPosition { get; set; }
        public virtual ICollection<PRJProject> Project { get; set; }
        public virtual ICollection<PRJProjectCategory> ProjectCategory { get; set; }
        public virtual ICollection<PRJProjectFollowers> ProjectFollowers { get; set; }
        public virtual ICollection<PRJProjectHistory> ProjectHistory { get; set; }
        public virtual ICollection<PRJProjectRole> ProjectRole { get; set; }
        public virtual ICollection<PRJProjectStatus> ProjectStatus { get; set; }
        public virtual ICollection<PRJTAG> Tag { get; set; }
        public virtual ICollection<PRJTask> Task { get; set; }
        public virtual ICollection<PRJTaskFollower> TaskFollower { get; set; }
        public virtual ICollection<PRJTaskHistory> TaskHistory { get; set; }
        public virtual ICollection<PRJTaskStatus> TaskStatus { get; set; }
        public virtual ICollection<PRJTimeSheet> TimeSheets { get; set; }
    }
}