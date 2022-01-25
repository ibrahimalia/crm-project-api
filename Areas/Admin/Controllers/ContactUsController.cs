using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Contact;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class ContactUsController : BaseAdminController
    {
        //inject the repositories and dbcontext class

        private readonly IAdminContactUsService conntactService;

        public ContactUsController(IAdminContactUsService con)
        {
            this.conntactService = con;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ContactUs")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<AddOrUpdateContactDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ContactUs()
        {
            return SuccessResponse(await conntactService.GetContactUs());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseAPIResult> ContactUs([Required(AllowEmptyStrings = false)] ContactUSList model)
        {
            await conntactService.AddOrUpdateContactUsList(model.ContactMethods , model.SocialContacts);
            return BaseSuccessResponse();
        }
    }
}