//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminNewsService
    {
        Task<GetNewsDTO> GetNewsDetailes(int? NewsId);

        Task AddNews(AddEditNewsDTO news);

        Task<List<GetNewsDTO>> GetNews(PaginationFilterDTO filter);

        Task UpdateNews(int newsId, AddEditNewsDTO news);

        Task DeleteNews(int newsId);

        Task<List<GetNewsDTO>> GetHomePageNews();
    }
}