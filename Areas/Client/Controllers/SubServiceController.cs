using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.SubService;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Services;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    public class SubServicesController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientSubServicesService _SubServices;

        public SubServicesController(IClientSubServicesService _SubServices)
        {
            this._SubServices = _SubServices;
        }

        /// <summary>
        /// return Sub_Service information for specific service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<SubServiceDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> SubService([Required] int? id)
        {
            return SuccessResponse(await _SubServices.GetSubService(id));
        }

        /// <summary>
        /// return all sub_services for specific service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<UpdateSubServiceDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> SubServices([Required(AllowEmptyStrings = false)] int serviceId)
        {

            return SuccessResponse( await _SubServices.GetSubServices(serviceId));


        }

        /// <summary>
        /// return all sub_services for specific Merchant
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("All")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<UpdateSubServiceDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AllSubServices()
        {

            return SuccessResponse(await _SubServices.GetAllSubServices());


        }
    }
}