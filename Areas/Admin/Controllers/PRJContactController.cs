using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_Contacts;
using Meta.IntroApp.Services.PRJ_Contacts.admin;
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
    public class PRJContactController : BaseAdminController
    {
        private readonly PRJIAdminContact _contact;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJContactController(PRJIAdminContact contact, IHttpContextAccessor httpContextAccessor)
        {
            _contact = contact;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get list of contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<PRJGetContactsDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListContacts()
        {
            var contacts = await _contact.GetContacts();
            return SuccessResponse(contacts); 
        }


        /// <summary>
        /// Get many lists of values to add new contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet("DropDownData")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<DropdownsDataForAddcontact>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DropDownData()
        {
            var contacts = await _contact.GetDropdownsDataForAddcontact();
            return SuccessResponse(contacts);
        }




        /// <summary>
        /// Get detailes of contact
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<PRJGetContactsDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Contactdetailes([Required(AllowEmptyStrings = false)] int id)
        {
            var result = await _contact.GetContactDetailes(id);
            return SuccessResponse(result); ;
        }


        /// <summary>
        /// Add New Contact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Contacts")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Contacts(PRJAddContactsDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _contact.AddContact(adminId1, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update contact data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Contact/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateContact([Required(AllowEmptyStrings = false)] int id, PRJAddContactsDTO project)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _contact.UpdateContact(adminId1, id, project);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteContact([Required(AllowEmptyStrings = false)] int id)
        {
            await _contact.DeleteContact(id);
            return BaseSuccessResponse();
        }
        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
