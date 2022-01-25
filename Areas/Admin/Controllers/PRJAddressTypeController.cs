using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_AddressType;
using Meta.IntroApp.Services.PRJ_AddressType.admin;
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
    public class PRJAddressTypeController : BaseAdminController
    {
        private readonly IAdminAddressType _address;

        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJAddressTypeController(IAdminAddressType address, IHttpContextAccessor httpContextAccessor)
        {
            _address = address;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of Admin Address Type
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetAddressTypeDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListAddressType()
        {
            var result = await _address.GetAddressTypes();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New Address Type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddressType")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> AddressType(AddAddressTypeDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _address.AddAddressType(adminId1,model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update Address Type value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AddressType/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateAddressType([Required(AllowEmptyStrings = false)] int id, AddAddressTypeDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _address.UpdateAddressType(adminId1, id, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific Address Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteAddressType([Required(AllowEmptyStrings = false)] int id)
        {

            await _address.DeleteAddressType(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

    }
}
