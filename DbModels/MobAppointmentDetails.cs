using Meta.IntroApp.Enums;

using System;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobAppointmentDetails
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public int? SubServiceId { get; set; }
        public int? StaffId { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public AppointmentStatus? Status { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }

        public virtual MobAppointment Appointment { get; set; }
        public virtual MobSubService SubService { get; set; }
    }
}