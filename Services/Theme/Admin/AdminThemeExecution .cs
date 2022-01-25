using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Theme;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Extensions;
using Newtonsoft.Json;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminThemeService : BaseService, IAdminThemeService
    {
        private readonly MetaITechDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminThemeService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _context = context;
            _env = env;
        }

        public async Task SetGlobalTheme(ThemeDTO theme)
        {
           
            var oldTheme = _context.GlobalThemes.Where(x => x.MerchantId == CurrentMerchantId).FirstOrDefault();
            var logo = theme.ImageUrl?.RemoveContentUrl();
            //remove OldTheme
            if (oldTheme != null)
                _context.GlobalThemes.Remove(oldTheme);
            await _context.GlobalThemes.AddAsync(new MobGlobalTheme
            {
                BackGroundColor = theme.BackGroundColor ,
                FontColor = theme.FontColor,
                FontType = theme.FontType,
                GlobalColor = theme.GlobalColor,
                LayoutOrder = theme.LayoutOrder,
                NavBarColor = theme.NavBarColor,
                SideBarColor =  theme.SideBarColor,
                //IsActive = theme.IsActive,
                LogoImage = JsonConvert.SerializeObject(logo),
                MerchantId = CurrentMerchantId,
                BranchId = CurrentBranchId,
                GallerySlider = theme.GallerySliderVisibility,
                MainSlider = theme.MainSliderVisibilty,
                NewsSlider = theme.NewsSliderVisibility,
                ServicesSlider = theme.ServiceSliderVisibility,
                ProjectSlider = theme.ProjectSliderVisibilty,
                FontSize = theme.FontSize,
                SplashScreenColor = theme.SplashScreenColor,
                SplashScreenTitle = theme.SplashScreenTitle
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGlobalTheme(int id)
        {
            var theme = _context.GlobalThemes.Where(x => x.MerchantId == CurrentMerchantId && x.MobGlobalThemeId == id).FirstOrDefault();
            if (theme == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);
            _context.GlobalThemes.Remove(theme);
            await _context.SaveChangesAsync();
        }

        public async Task<ThemeDTO> GetGlobalTheme()
        {
            var theme = await _context.GlobalThemes.FirstOrDefaultAsync(x => x.MerchantId == CurrentMerchantId);
            if (theme == null)
                //throw new ApplicationException(AppExceptions.ThemeNotFound);
                return null;

            return new ThemeDTO
            {
                SideBarColor = theme.SideBarColor,
                NavBarColor = theme.NavBarColor,
                LayoutOrder = theme.LayoutOrder,
                GlobalColor = theme.GlobalColor,
                FontColor = theme.FontColor,
                FontType = theme.FontType,
                //IsActive = theme.IsActive,
                BackGroundColor = theme.BackGroundColor,
                ImageUrl = JsonConvert.DeserializeObject<string>(theme.LogoImage ?? "[]").WrapContentUrl(),
                MainSliderVisibilty = theme.MainSlider,
                ServiceSliderVisibility = theme.ServicesSlider,
                ProjectSliderVisibilty = theme.ProjectSlider,
                NewsSliderVisibility = theme.NewsSlider,
                GallerySliderVisibility = theme.GallerySlider,
                SplashScreenTitle = theme.SplashScreenTitle,
                SplashScreenColor =theme.SplashScreenColor,
                FontSize = theme.FontSize
            };
        }

        public async Task SetGallaryImages(List<GalleryImageDTO> images)
        {
            _context.Galleries.RemoveRange(await _context.Galleries.Where(x => x.MerchantId == CurrentMerchantId).ToArrayAsync());
            foreach (var image in images ?? new List<GalleryImageDTO>())
            {
                var gallery = new MobGallery
                {
                    Url = image.URL?.RemoveContentUrl(),                 
                    IsFeatured = image.IsFeatured,
                    MerchantId = CurrentMerchantId,
                    BranchId = CurrentBranchId
                };

                await _context.Galleries.AddAsync(gallery);
            }
            await _context.SaveChangesAsync();
        }


        public async Task SetSliderImages(List<GalleryImageDTO> images)
        {
            AppDbContext.Sliders.RemoveRange(await AppDbContext.Sliders.Where(s => s.MerchantId == CurrentMerchantId && (!CurrentBranchId.HasValue || s.BranchId == CurrentBranchId)).ToArrayAsync());
            foreach (var image in images ?? new List<GalleryImageDTO>())
            {
                var slider = new MobSlider
                {                  
                    IsFeatured = image.IsFeatured,
                    Link = image.URL?.RemoveContentUrl(),
                    MerchantId = CurrentMerchantId,
                    BranchId = CurrentBranchId
                };

                await _context.Sliders.AddAsync(slider);
            }
            await _context.SaveChangesAsync();
        }
    }
}