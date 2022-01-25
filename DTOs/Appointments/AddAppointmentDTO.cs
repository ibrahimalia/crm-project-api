using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Localizations.Tokens;
using Meta.IntroApp.Localizations.DataAnnotations;
using Meta.IntroApp.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace Meta.IntroApp.DTOs.DTO_Appointments
{
    public class AddAppointmentDTO
    {
        //[Display(Name = nameof(Tokens.PlanId), ResourceType = typeof(Tokens))]
        //[Required(ErrorMessageResourceType = typeof(DataAnnotations), ErrorMessageResourceName = nameof(DataAnnotations.FieldRequiredTemplate))]
        ////public int? PlanId { get; set; }

        /// <summary>
        /// Please just to sent the year ,month , day section
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        //public AppointmentStatus Status { get; set; }
        //public int SubServiceID { get; set; }
        //public int StaffId { get; set; }
        public string StartTime { get; set; }
        /// <summary>
        /// Syntax: hh:mm
        /// </summary>
        //public int StartHour { get; set; }
        //public int StartMinute { get; set; }
        public string PhoneNumber { get; set; }
        //public int FinishHour { get; set; }
        //public int FinishMinute { get; set; }
        //public string Notes { get; set; }
        //public AppointmentStatus CurrentStatus { get; set; }
        public string Notes { get; set; }
    }
}