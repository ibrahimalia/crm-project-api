using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Contact;

using Microsoft.AspNetCore.Mvc;

//using Meta.IntroApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Areas.Client.Controllers.Client;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class ContactUsController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientContactUs con;

        public ContactUsController(IClientContactUs con)
        {
            this.con = con;
        }

    
        [HttpGet]    
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<ContactUSList>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ContactUs()
        {
            return SuccessResponse(await con.GetContactUs());          
        }

   
    }
}