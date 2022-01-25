//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientNewsService
    {
        Task<GetNewsDTO> GetNewsDetailes(int? NewsId);

        Task<List<GetNewsDTO>> GetNews(PaginationFilterDTO filter);

        Task<List<GetNewsDTO>> GetHomePageNews();
    }
}