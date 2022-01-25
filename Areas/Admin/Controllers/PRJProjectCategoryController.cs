using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.PRJ_ProjectCategoriesDTO;
using Meta.IntroApp.Services.PRJ_ProjectCategory.admin;
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
    public class PRJProjectCategoryController : BaseAdminController
    {
        private readonly IAdminProjectCategory _category;
        public IHttpContextAccessor _httpContextAccessor { get; }

        public PRJProjectCategoryController(IAdminProjectCategory category, IHttpContextAccessor httpContextAccessor)
        {
            _category = category;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Get list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetProjectCategoriesDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ListProjectCategories()
        {
            var result = await _category.GetProjectCategories();
            return SuccessResponse(result); ;
        }

        /// <summary>
        /// Add New project categpry
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Category")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> ProjectCategory(ADDProjectCategoriesDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _category.AddProjectCategory(adminId1 ,model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// update category value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Category/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> UpdateProjectCategory([Required(AllowEmptyStrings = false)] int id, ADDProjectCategoriesDTO model)
        {
            var adminId = GetCurrentUserId();
            int adminId1 = int.Parse(adminId);
            await _category.UpdateProjectCategory(adminId1 ,id, model);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// delete specific category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> DeleteProjectCategory([Required(AllowEmptyStrings = false)] int id)
        {
            await _category.DeleteProjectCategory(id);
            return BaseSuccessResponse();
        }

        protected string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
