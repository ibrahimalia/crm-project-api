using Meta.IntroApp.DTOs.DTO_Appointments;
using Meta.IntroApp.DTOs.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientAppointmentService
    {
        Task<List<AppointmentDTO>> ListAppointments(long clientID , PaginationFilterDTO filter);
        Task<List<AppointmentDetailesDTO>> GetAppointmentDetailes(int? appointmentId);
        Task AddAppointment(long clientID, AddAppointmentDTO news);
        Task UpdateAppointment(int appointmentId, AddAppointmentDTO news);
        Task DeleteAppointment(int appointmentId);
        Task<List<string>> GetAvailableTimes(DateTime date, bool checkAvailableTimes = false);
    }
}