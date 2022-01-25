//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientNewsService : BaseService, IClientNewsService
    {
        public ClientNewsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<GetNewsDTO>> GetHomePageNews()
        {
            List<GetNewsDTO> news = new List<GetNewsDTO>();

            var c = await AppDbContext.News.Where(o => o.MerchantId == CurrentMerchantId && o.IsActive == 1)
                                                  .OrderByDescending(x => x.NewsId)
                                                  .ToListAsync();

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
                Images = JsonConvert.DeserializeObject<List<string>>(c.Images?? "[]").Select(x => x.WrapContentUrl())
            }); 
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
                Images = JsonConvert.DeserializeObject<List<string>>(subResult.Images?? "[]").Select(x => x.WrapContentUrl())
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
                Images = JsonConvert.DeserializeObject<List<string>>(c.Images?? "[]").Select(x => x.WrapContentUrl())
            });
        }

        #region function
        public List<GalleryImageDTO> getListOfObjects(string images)
        {
            List<GalleryImageDTO> result = new List<GalleryImageDTO>();

            if (images.Substring(0, 1) != "{")
            {
                string one;
                String[] strings = images.Split("}");
                for (int j = 0; j < strings.Length - 1; j++)
                {
                    if (j == 0)
                    {
                        one = strings[j].Remove(0, 1);
                        one += "}";
                    }
                    else
                    {
                        one = strings[j].Replace(",{", "{");
                        //    one = strings[j].Remove(0, 1);
                        one += "}";
                    }

                    JObject jObj1 = (JObject)JsonConvert.DeserializeObject(one);
                    int number1 = jObj1.Count;

                    var l = JsonConvert.DeserializeObject<GalleryImageDTO>(one);
                    result.Add(l);

                    return result;
                }
            }
            else
            {
                JObject jObj = (JObject)JsonConvert.DeserializeObject(images);
                int number = jObj.Count;

                for (int j = 0; j < number; j += 5)
                {
                    var one = JsonConvert.DeserializeObject<GalleryImageDTO>(images);
                    result.Add(one);
                }

                return result;
            }
            return result;
        }
        #endregion
    }
}