using Meta.IntroApp.Enums;

using System;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobAppointment
    {
        public MobAppointment()
        {
            MobAppointmentDetails = new HashSet<MobAppointmentDetails>();
        }

        public int Id { get; set; }
        public long ClientId { get; set; }
        public int? WorkPlanId { get; set; }
        public string MerchantId { get; set; }
        public int? BranchId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public virtual MobBranch Branch { get; set; }
        public virtual Account Client { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        public virtual MobWorkPlan WorkPlan { get; set; }
        public virtual ICollection<MobAppointmentDetails> MobAppointmentDetails { get; set; }
    }
}