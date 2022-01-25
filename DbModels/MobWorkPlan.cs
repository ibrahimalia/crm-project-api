using System;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobWorkPlan
    {
        public MobWorkPlan()
        {
            MobAppointments = new HashSet<MobAppointment>();
        }

        public int Id { get; set; }
        public string PlanName { get; set; }
        public DateTime? FromDay { get; set; }
        public DateTime? ToDay { get; set; }
        public DateTime? FirstWorkTimeStart { get; set; }
        public DateTime? FirstWorkTimeEnd { get; set; }
        public DateTime? SecondWorkTimeStart { get; set; }
        public DateTime? SecondWorkTimeEnd { get; set; }
        public string MerchantId { get; set; }
        public int? BranchId { get; set; }
        public string Notes { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        public virtual ICollection<MobAppointment> MobAppointments { get; set; }
    }
}