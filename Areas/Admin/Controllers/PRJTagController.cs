using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_Tag;
using Meta.IntroApp.Services.PRJ_Tag.admin;
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
    public class PRJTagController : BaseAdminController
    {
        private readonly ITagAdmin _tag;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJTagController(ITagAdmin tag, IHttpContextAccessor httpContextAccessor)
        {
            _tag = tag;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of tags
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetTagDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListTags()
        {
            var tags = await _tag.GetTags();
            return SuccessResponse(tags); ;
        }

        /// <summary>
        /// Add New Tag
        /// </summary>
        /// <param name="tag"></param>
       
        /// <returns></returns>
        [HttpPost]
        [Route("Tag")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Tags( AddTagDTO tag)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _tag.AddTag(adminId1 , tag);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Update Tag data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Tag/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateTag([Required(AllowEmptyStrings = false)] int id, AddTagDTO tag)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _tag.UpdateTag(adminId1 ,id, tag);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteTag([Required(AllowEmptyStrings = false)] int id)
        {
            await _tag.DeleteTag(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
