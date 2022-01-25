using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.DTO_Appointments;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    
    public class AppointmentController : BaseClientController
    {
        private readonly IClientAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentController(IClientAppointmentService Appointment, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = Appointment;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///Appointments Status : Pending = 1 , Cancelled = 2,  Arrived = 3, Done = 4
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<AppointmentDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetAppointment([FromQuery] PaginationFilterDTO filter)
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            return SuccessResponse(await _appointmentService.ListAppointments(clientId1 , filter));

        }



        /// <summary>
        /// return List of available times 
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListOfTimes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<string>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetAvailableTimes(DateTime date, bool checkAvailableTimes = false)
        {
            return SuccessResponse(await _appointmentService.GetAvailableTimes(date, checkAvailableTimes));
        }


        /// <summary>
        /// get appointment detailes
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<AppointmentDetailesDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<APIResult<List<AppointmentDetailesDTO>>> GetAppointmentDetailes([Required(AllowEmptyStrings = false)] int? AppointmentId)
        {

            return SuccessResponse(await _appointmentService.GetAppointmentDetailes(AppointmentId));

        }

        /// <summary>
        /// 
        /// </summary>       
        /// <param name="model"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddAppointment(AddAppointmentDTO model) 
        {
            var clientId = GetCurrentUserId();
            long clientId1 = long.Parse(clientId);
            await _appointmentService.AddAppointment(clientId1, model);
            return BaseSuccessResponse();
        }


        /// <summary>
        /// Delete Pending appointment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Appointment/{Id}")]
        public async Task<BaseAPIResult> delete([Required(AllowEmptyStrings = false)]int Id)
        {
            await _appointmentService.DeleteAppointment(Id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }  
}