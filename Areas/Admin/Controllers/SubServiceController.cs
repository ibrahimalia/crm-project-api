using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.SubService;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class SubServicesController : BaseAdminController
    {
        //inject the repositories and dbcontext class

        private readonly IAdminSubServicesService _SubServices;

        public SubServicesController(IAdminSubServicesService _SubServices)
        {
            this._SubServices = _SubServices;
        }

        /// <summary>
        /// return specific Sub_Service information 
        /// </summary>
        /// <param name="SubServiceId"></param>
        /// <returns></returns>
        [HttpGet("{SubServiceId}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<SubServiceDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetSubService([Required] int? SubServiceId)
        {
            return SuccessResponse(await _SubServices.GetSubService(SubServiceId));
        }

        /// <summary>
        /// return all sub_services for specific service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<UpdateSubServiceDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetSubServices([Required] int serviceId)
        {
            return SuccessResponse(await _SubServices.GetSubServices(serviceId));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="Subservice"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddSubService([Required] int serviceId, SubServiceDTO Subservice)
        {
            await _SubServices.AddSubServiceAsync(serviceId, Subservice);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>

        [HttpPut]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> PutSubServices(UpdateSubServiceDTO service)
        {
            await _SubServices.UpdateSubService(service);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subServiceId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<BaseAPIResult> Delete([Required(AllowEmptyStrings = false)] int subServiceId)
        {
            await _SubServices.DeleteSubServiceAsync(subServiceId);
            return BaseSuccessResponse();

        }
    }
}