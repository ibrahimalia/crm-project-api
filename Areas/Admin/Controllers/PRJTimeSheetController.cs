using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_TimeSheet;
using Meta.IntroApp.Services.PRJ_TimeSheet.Admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJTimeSheetController : BaseAdminController
    {
        private readonly IAdminTimesheet _timesheet;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJTimeSheetController(IAdminTimesheet timesheet, IHttpContextAccessor httpContextAccessor)
        {
            _timesheet = timesheet;
            _httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        ///This API for ((admin)) Get list of timesheets for specific user / if [userId] was null the result will be list of all time sheets
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTimeSheetDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListTimeSheetDTO(long? userID)
        {
            if (userID == null)
            {
                var result = await _timesheet.GetTimeSheets();
                return SuccessResponse(result);
            }
            var result1 = await _timesheet.GetTimeSheets(userID);
            return SuccessResponse(result1); 
        }

        /// <summary>
        ///This API for ((user)) to Get list of his TimeSheets //Authenticated
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListOfTimeSheets")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTimeSheetDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AuthListTimeSheetDTO()
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            var result1 = await _timesheet.GetTimeSheets(adminId1);
            return SuccessResponse(result1);
        }




        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetTimeSheetDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> TimeSheetDetailes([Required(AllowEmptyStrings =false)]int id)
        {

            var result = await _timesheet.GetTimeSheetDetailes(id);
            return SuccessResponse(result);
        }




        /// <summary>
        /// Add New time sheet , the user must be loggedIn
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTimeSheet")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddTimeSheetDTO(AddTimeSheetDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _timesheet.AddTimeSheet(adminId1 , model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update Time Sheet , the user must be loggedIn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("TimeSheet/{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateTag([Required(AllowEmptyStrings = false)] int id, AddTimeSheetDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _timesheet.UpdateTimeSheet(adminId1,model);
            return BaseSuccessResponse();
        }

      

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}