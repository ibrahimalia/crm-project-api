using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_Contacts;
using Meta.IntroApp.Services.PRJ_Contacts.admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class InfoProjectManagrController : BaseAdminController 
    {
        private readonly PRJIAdminContact _contact;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public  InfoProjectManagrController(PRJIAdminContact contact, IHttpContextAccessor httpContextAccessor)
        {
            _contact = contact;
            _httpContextAccessor = httpContextAccessor;
        } 
        
        /// <summary>
        /// Get Project Manager 
        /// </summary>
        /// <returns></returns>
        
       
        [Microsoft.AspNetCore.Mvc.HttpGet("ProjectManager")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<PRJContactProjectManagerDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListContactsProjectManager()
        {
            var contacts = await _contact.GetDataPRojectManager();
            return SuccessResponse(contacts); 
        }
    }
}