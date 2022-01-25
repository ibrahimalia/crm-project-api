using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.DTO_Appointments;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Services;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class AppointmentController : BaseAdminController
    {
        private readonly IAdminAppointmentService _appointmentService;

        public AppointmentController(IAdminAppointmentService Appointment)
        {
            _appointmentService = Appointment;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseAPIResult> AddAppointment( long clientId, AddAppointmentDTO appointment)
        {
            await _appointmentService.AddAppointment(clientId ,appointment);
            return BaseSuccessResponse(); 
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Appointment/{Id}")]
        public async Task<BaseAPIResult> delete(int Id)
        {
            await _appointmentService.DeleteAppointment(Id);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<APIResult<List<AppointmentDTO>>> GetAppointment(long clientId, PaginationFilterDTO filter)
        {
            var result = await _appointmentService.ListAppointments(clientId, filter);
            return SuccessResponse(result);
        }




        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        public async Task<APIResult<List<AppointmentDetailesDTO>>> Details(int? id)
        {
            var result = await _appointmentService.GetAppointmentDetailes(id);
            return SuccessResponse(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<BaseAPIResult> Update(int id, AddAppointmentDTO model)
        {
            await _appointmentService.UpdateAppointment(id, model);
            return BaseSuccessResponse();
        }
    }
}