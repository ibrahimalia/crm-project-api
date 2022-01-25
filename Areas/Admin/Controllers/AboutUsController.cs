using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;

using Meta.IntroApp.Services;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class AboutUsController : BaseAdminController
    {
        private readonly IAdminAboutUsService _aboutService;

        public AboutUsController(IAdminAboutUsService aboutService)
        {
            this._aboutService = aboutService;
        }

        /// <summary>
        /// Get about_us information
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "AcceptNameUserSpecific")] 
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetAboutUsDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetAboutUs()
        {
//            if (HttpContext.Current.User.IsInRole("Admin"))
//            {
//                
//            }
            return SuccessResponse(await _aboutService.GetAboutUs());
        }

        /// <summary>
        /// Add or Update aboutUs information
        /// </summary>
        /// <param name="aboutUs"></param>
        /// <returns></returns>
        //[Authorize(Roles = "AdminUser")]
        [HttpPost]
        public async Task<BaseAPIResult> AddAboutUs(AddAboutUSDTO aboutUs)
        {
            await _aboutService.AddAboutUsInfo(aboutUs);
            return BaseSuccessResponse();
        }


        /// <summary>
        /// update about us information
        /// </summary>
        /// <param name="aboutUs"></param>
        /// <returns></returns>
        //[Authorize(Roles = "AdminUser")]
        //[Authorize]
        //[HttpPut]
        //[ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        //public async Task<BaseAPIResult> AboutUsUPDATE([FromBody] AddAboutUSDTO aboutUs)
        //{
        //    await _aboutService.UpdateAboutUsInfo(aboutUs);
        //    return BaseSuccessResponse();
        //}

        /// <summary>
        /// Post or Put List of employee information
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("OurTeam")]
        //[Authorize]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddOurTeam(List<AddEmployeeDTO> employee)
        {
            await _aboutService.AddEmployee(employee);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("AssignService")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AssignService([Required]int? employeeId,[Required] int? service)
        {
            await _aboutService.AssignServiceToEmployee(employeeId.Value, service.Value);
            return BaseSuccessResponse();
        }

        [HttpGet("OurTeam")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<ListEmployeeDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetOurTeam()
        {
            return SuccessResponse(await _aboutService.GetEmployees());
        }

        /// <summary>
        /// update employee info
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        //[Authorize]
        //[HttpPut("OurTeam")]
        //[ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        //public async Task<BaseAPIResult> OurTeam([FromBody]UpdateEmployeeDTO employee)
        //{
        //    await _aboutService.UpdateEmployeeInfo(employee);
        //    return BaseSuccessResponse();
        //}

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete("OurTeam")]
        //[Authorize]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteOurTeam([Required(AllowEmptyStrings = false)]int? employeeId)
        {
            await _aboutService.DeleteEmployee(employeeId.Value);
            return BaseSuccessResponse();
        }
    }
}