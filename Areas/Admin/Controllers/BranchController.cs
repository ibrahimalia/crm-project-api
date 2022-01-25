using Meta.IntroApp.DTOs;

//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class BranchController : BaseAdminController
    {
        //inject the repositories and dbcontext class

        private readonly IAdminBranchesService _BranchesService;

        public BranchController(IAdminBranchesService _Branches)
        {
            this._BranchesService = _Branches;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetBranchDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Branches([FromQuery] PaginationFilterDTO filter)
        {
            var result = await _BranchesService.GetBranches(filter);
            return SuccessResponse(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetBranchDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Branche([Required] int? id)
        {
            return SuccessResponse(await _BranchesService.GetBranchDetailes(id.Value));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mobBranch"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Branches(AddBranchDTO mobBranch)
        {
            await _BranchesService.AddBranch(mobBranch);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Update(AddBranchDTO branch)
        {
            await _BranchesService.UpdateBranch(branch);
            return BaseSuccessResponse();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(statusCode: 200, Type = typeof(BaseAPIResult))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Delete([Required] int? id)
        {
            await _BranchesService.DeleteBranch(id.Value);
            return BaseSuccessResponse();
        }
    }
}