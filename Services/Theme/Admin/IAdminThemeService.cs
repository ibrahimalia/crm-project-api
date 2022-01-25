using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Theme;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminThemeService
    {
        Task SetGallaryImages(List<GalleryImageDTO> images);
        Task SetSliderImages(List<GalleryImageDTO> images);
        Task DeleteGlobalTheme(int id);
        Task<ThemeDTO> GetGlobalTheme();
        Task SetGlobalTheme(ThemeDTO theme);
    }
}