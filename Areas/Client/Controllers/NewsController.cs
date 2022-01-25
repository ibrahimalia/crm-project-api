using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;

//using Meta.IntroApp.Models;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class NewsController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientNewsService _news;

        public NewsController(IClientNewsService _news)
        {
            this._news = _news;
        }
        /// <summary>
        /// return list of news
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("List")]       
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<List<GetNewsDTO>>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]  
        public async Task<BaseAPIResult> News([FromQuery] PaginationFilterDTO filter)
        {
              
                return SuccessResponse(await _news.GetNews(filter));
        }

        /// <summary>
        ///return news detailes
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<GetNewsDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> New([Required(AllowEmptyStrings = false)] int? newsId)
        {

           return SuccessResponse(await _news.GetNewsDetailes(newsId));
        }               

   
    }
}