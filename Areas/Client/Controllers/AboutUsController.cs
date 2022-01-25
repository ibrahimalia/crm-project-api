using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;
//using Meta.IntroApp.Models;
using Meta.IntroApp.Services;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    public class AboutUsController : BaseClientController
    {
       
        //inject the repositories and dbcontext class

        private readonly IClientAboutUsService about;

        public AboutUsController(IClientAboutUsService _about)
        {
            about = _about;
        }

        /// <summary>
        /// Get about_us information
        /// </summary>
        /// <returns></returns>
        [HttpGet("Aboutus")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetAboutUsDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetAboutUsPage()
        {
            return SuccessResponse(await about.GetAboutUs());
        }     

  
        /// <summary>
        /// return list of employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("OurTeam")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<AddEmployeeDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetOurTeam()
        {
            return SuccessResponse(await about.GetEmployees());
        }

        /// <summary>
        /// return the gallery images in home page
        /// </summary>
        /// <returns></returns>
        [HttpGet("HomeGallery")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GalleryImageDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetHomeGallery() 
        {
            return SuccessResponse(await about.GetHomePageImages());
        }

     
    }
}