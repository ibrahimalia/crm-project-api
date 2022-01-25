using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_InvolvementLevel;
using Meta.IntroApp.Services.PRJ_InvolvementLevel.admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class PRJInvolvementLevelController : BaseAdminController
    {
        private readonly IAdminInvolvementLevel _level;

        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJInvolvementLevelController(IAdminInvolvementLevel level, IHttpContextAccessor httpContextAccessor)
        {
            _level = level;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of Levels
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetInvolvementLevelDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListLevels()
        {
            var result = await _level.GetLevels();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New Level
        /// </summary>
        /// <param name="levelDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Levels")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Levels(AddInvolvementLevelDTO levelDTO)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _level.AddLevel(adminId1, levelDTO);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update Level value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="levelDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Level/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateLevel([Required(AllowEmptyStrings = false)] int id, AddInvolvementLevelDTO levelDTO)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _level.UpdateLevel(adminId1, id,levelDTO);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific level
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteLevel([Required(AllowEmptyStrings = false)] int id)
        {

            await _level.DeleteLevel(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

    }
}
