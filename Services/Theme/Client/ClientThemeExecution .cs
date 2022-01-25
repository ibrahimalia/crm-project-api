using Meta.IntroApp.DTOs;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Client
{
    public class ClientThemeExecution : BaseService, IClientThemeExecution
    {
        private readonly MetaITechDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ClientThemeExecution(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<GalleryImageDTO>> GetSliders()
        {
            var slides = await AppDbContext.Sliders.Where(x => x.MerchantId == CurrentMerchantId && x.IsFeatured == 1).ToListAsync();
            return slides?.ConvertAll(s => new GalleryImageDTO
            {
                URL = (s.Link).WrapContentUrl(),         
                IsFeatured = s.IsFeatured
            });
        }
    }
}