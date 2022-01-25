using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.service;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class ServiceController : BaseAdminController
    {
        //inject the repositories and dbcontext class

        private readonly IAdminServicesService _ServicesService;

        public ServiceController(IAdminServicesService _Services)
        {
            this._ServicesService = _Services;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<ServiceDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetServices()
        {
            return SuccessResponse(await _ServicesService.List());
        }

        [HttpGet("{ServiceId}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<ServiceDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetService(int? ServiceId)
        {
            var service = await _ServicesService.Details(ServiceId);
            return SuccessResponse(service);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddService(AddServiceDTO model)
        {
            await _ServicesService.AddServiceAsync(model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceID"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Update([Required] int serviceID, EditServiceDTO model)
        {
            await _ServicesService.UpdateService(serviceID, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Delete([Required] int? id)
        {
            await _ServicesService.DeleteServiceAsync(id.Value);
            return BaseSuccessResponse();
        }
    }
}