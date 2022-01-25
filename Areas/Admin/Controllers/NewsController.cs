//using Meta.IntroApp.Models;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class NewsController : BaseAdminController
    {

        private readonly IAdminNewsService _newsService;

        public NewsController(IAdminNewsService _news)
        {
            this._newsService = _news;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("List")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetNewsDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        //[Authorize(Roles = "Tester")]
        public async Task<BaseAPIResult> GetListNews([FromQuery] PaginationFilterDTO filter)
        {
            return SuccessResponse(await _newsService.GetNews(filter));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        [HttpGet("Details")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetNewsDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetNews([Required(AllowEmptyStrings = false)] int? newsId)
        {
            return SuccessResponse(await _newsService.GetNewsDetailes(newsId));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>

        [HttpPost]
        //[Authorize(Roles = "Tester")]
        public async Task<BaseAPIResult> AddNews(AddEditNewsDTO news)
        {
            await _newsService.AddNews(news);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<BaseAPIResult> Update([Required] int? newsId, AddEditNewsDTO news)
        {
            await _newsService.UpdateNews(newsId.Value, news);

            return BaseSuccessResponse();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<BaseAPIResult> Delete([Required(AllowEmptyStrings = false)] int newsId)
        {
            await _newsService.DeleteNews(newsId);
            return BaseSuccessResponse();
        }
    }
}