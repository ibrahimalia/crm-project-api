using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.service;
using Meta.IntroApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    public class ServiceController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientServicesService _ServicesService;

        public ServiceController(IClientServicesService _Services)
        {
            this._ServicesService = _Services;
        }

        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<ServiceDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Services()
        {
            return SuccessResponse(await _ServicesService.GetServices());
        }

        [HttpGet("{ServiceId}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<ServiceDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Service([Required(AllowEmptyStrings = false)] int? ServiceId)
        {
            return SuccessResponse(await _ServicesService.GetService(ServiceId));
        }

    
    }
}