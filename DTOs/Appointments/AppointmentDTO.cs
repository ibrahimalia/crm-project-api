using Meta.IntroApp.Enums;

namespace Meta.IntroApp.DTOs.DTO_Appointments
{
    public class AppointmentDTO
    {
        public int Id {get; set;}
        //public int? PlanId { get; set; }
        public string AppointmentDate { get; set; }
        public string BookingDate { get; set; }

        /// <summary>
        /// To be displyed only : Appointments Status : Pending = 1 , Cancelled = 2,  Arrived = 3, Done = 4
        /// </summary>
        public string? StatusText { get; set; }

        //public long ClientId { get; set; }

        public AppointmentStatus? Status { get; set; }
        public string AppointmentTime { get; set; }
     
    }
}