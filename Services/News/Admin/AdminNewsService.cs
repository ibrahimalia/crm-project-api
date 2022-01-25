//using Meta.IntroApp.Models;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Extensions;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminNewsService : BaseService, IAdminNewsService
    {
        public AdminNewsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task AddNews(AddEditNewsDTO news)
        {
            MobNews news1 = new MobNews
            {
                Description = news.Description,
                BranchId = CurrentBranchId,
                MerchantId = CurrentMerchantId,
                Title = news.Title,
                IsPublished = news.IsPublished,
                IsActive = news.IsActive,
                SubTitle = news.SubTitle,
                PublishingDate = news.PublishingDate,
                Images = JsonConvert.SerializeObject(news.Images)
            };
            await AppDbContext.News.AddAsync(news1);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteNews(int newsId)
        {
            var deletedNews = await AppDbContext.News.Where(p => p.MerchantId == CurrentMerchantId
                                                              && (!CurrentBranchId.HasValue || p.BranchId == CurrentBranchId)
                                                              && p.NewsId == newsId
                                                              && p.BranchId == CurrentBranchId)
                                                        .FirstOrDefaultAsync();

            if (deletedNews == null)
                throw new ApplicationException(AppExceptions.NewsNotFound);
            {
                AppDbContext.News.Remove(deletedNews);
                await AppDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<GetNewsDTO>> GetHomePageNews()
        {
            List<GetNewsDTO> news = new List<GetNewsDTO>();

            var c = await AppDbContext.News.Where(o => o.MerchantId == CurrentMerchantId && o.IsActive == 1)
                                                  .OrderByDescending(x => x.NewsId)
                                                  .Take(5).ToListAsync();

            if (c.Count == 0)
            {
                return null;
            }
            return c.ConvertAll(c => new GetNewsDTO
            {
                ID = c.NewsId,
                Description = c.Description,
                IsActive = c.IsActive,
                IsPublished = c.IsPublished,
                PublishingDate = c.PublishingDate.Value.ToString("yyyy-MM-dd"),
                SubTitle = c.SubTitle,
                Title = c.Title,
                Images = JsonConvert.DeserializeObject<List<string>>(c.Images??"[]").Select(x => x.WrapContentUrl())
            }); ;
        }

        public async Task<GetNewsDTO> GetNewsDetailes(int? NewsId)
        {
            MobNews subResult = await AppDbContext.News.Where(o => o.MerchantId == CurrentMerchantId
                                                        && o.NewsId == NewsId
                                                        && (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId))
                                                      .FirstOrDefaultAsync();

            if (subResult == null)
            {
                return null;
            }
            GetNewsDTO result = new GetNewsDTO
            {
                ID = NewsId,
                Description = subResult.Description,
                IsActive = subResult.IsActive,
                IsPublished = subResult.IsPublished,
                PublishingDate = subResult.PublishingDate.Value.ToString("yyyy-MM-dd"),
                SubTitle = subResult.SubTitle,
                Title = subResult.Title,
                Images = JsonConvert.DeserializeObject<List<string>>(subResult.Images??"[]").Select(x => x.WrapContentUrl())
            };

            return result;
        }

        public async Task<List<GetNewsDTO>> GetNews(PaginationFilterDTO filter)
        {
            var validFilter = new PaginationFilterDTO(filter.PageNumber, filter.PageSize);

            List<GetNewsDTO> news = new List<GetNewsDTO>();

            var result = await AppDbContext.News.Where(o => (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId) && o.MerchantId == CurrentMerchantId && o.IsActive == 1)
                             .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                             .Take(validFilter.PageSize)
                             .ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }
            return result.ConvertAll(c => new GetNewsDTO
            {
                ID = c.NewsId,
                Description = c.Description,
                IsActive = c.IsActive,
                IsPublished = c.IsPublished,
                PublishingDate = (c.PublishingDate != null) ? c.PublishingDate.Value.ToString("yyyy-MM-dd") : "not determined",
                SubTitle = c.SubTitle,
                Title = c.Title,
                Images = JsonConvert.DeserializeObject<List<string>>(c.Images ?? "[]").Select(x=> x.WrapContentUrl())
            });
        }

        public async Task UpdateNews(int newsId, AddEditNewsDTO news)
        {
            MobNews oldNews = await AppDbContext.News.Where(o => (!CurrentBranchId.HasValue || o.BranchId == CurrentBranchId)
                                                           && o.MerchantId == CurrentMerchantId
                                                           && o.NewsId == newsId).
                                                           FirstOrDefaultAsync();

            if (oldNews == null)
                throw new ApplicationException(AppExceptions.NewsNotFound);

            oldNews.Description = news.Description;
            oldNews.Title = news.Title;
            oldNews.SubTitle = news.SubTitle;
            oldNews.IsPublished = news.IsPublished;
            oldNews.PublishingDate = news.PublishingDate;
            oldNews.IsActive = news.IsActive;
            oldNews.Images = JsonConvert.SerializeObject(news.Images);

            AppDbContext.News.Update(oldNews);
            await AppDbContext.SaveChangesAsync();
        }
    }
}