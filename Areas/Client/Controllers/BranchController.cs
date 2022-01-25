using Meta.IntroApp.Areas.Client.Controllers.Client;
using Meta.IntroApp.DTOs;

//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.branch;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Meta.IntroApp.Areas.Client.Controllers
{
    public class BranchController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientBranches _BranchesService;

        public BranchController(IClientBranches _Branches)
        {
            this._BranchesService = _Branches;
        }

        /// <summary>
        ///return list of branches
        /// </summary>
        /// <returns></returns>
      
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetBranchDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetListOfBranches([FromQuery] PaginationFilterDTO filter)
        {
            return SuccessResponse(await _BranchesService.GetBranches(filter));
        }

        /// <summary>
        /// return detailes information about the branch
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetBranchDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetBrancheDetailes([Required(AllowEmptyStrings = false)] int? id)
        { 
            return SuccessResponse(await _BranchesService.GetBranchDetailes(id.Value));
        }

    
    }
}