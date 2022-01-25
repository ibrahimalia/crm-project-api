using Meta.IntroApp.DbModels;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobSubService
    {
        public MobSubService()
        {
            MobAppointmentDetailes = new HashSet<MobAppointmentDetails>();
            MobImages = new HashSet<MobImage>();
            MobStaffServiceAssigns = new HashSet<MobStaffServiceAssign>();
            MobRequest = new HashSet<MobRequest>();
        }

        public int SubServicesId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? IsFeatured { get; set; }
        public int? ServiceId { get; set; }
        public int? IsActive { get; set; }
        public string Images { get; set; }

        public virtual MobService Service { get; set; }
        public virtual ICollection<MobAppointmentDetails> MobAppointmentDetailes { get; set; }
        public virtual ICollection<MobImage> MobImages { get; set; }
        public virtual ICollection<MobStaffServiceAssign> MobStaffServiceAssigns { get; set; }
        public virtual ICollection<MobRequest> MobRequest { get; set; }
    }
}