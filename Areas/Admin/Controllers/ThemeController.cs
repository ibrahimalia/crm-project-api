using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Theme;
using Meta.IntroApp.Services;
using Meta.IntroApp.Services.Admin;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers.Admin
{
    public class ThemeController : BaseAdminController
    {
        //inject the repositories and dbcontext class

        private readonly IAdminThemeService _themeService;
        private readonly IAdminProjectService _projectService;
        private readonly IAdminNewsService newsService;
        private readonly IAdminServicesService _servicesService;
        private readonly IAdminAboutUsService _aboutUsService;
        private readonly IAdminSubServicesService subService;

        public ThemeController(IAdminThemeService theme, MetaITechDbContext context, IAdminProjectService project,
                                   IAdminNewsService news, IAdminAboutUsService aboutusService, IAdminServicesService servicesService, IAdminSubServicesService subServicesService)
        {
            this._themeService = theme;
            this._projectService = project;
            this.newsService = news;
            this._servicesService = servicesService;
            this._aboutUsService = aboutusService;
            subService = subServicesService;
        }

        /// <summary>
        ///Get theme detailes
        /// </summary>
        /// <returns></returns>
        [HttpGet("Detailes")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<ThemeDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> Themes()
        {
            return SuccessResponse(await _themeService.GetGlobalTheme());
        }

        /// <summary>
        /// Post or Put Theme data
        /// </summary>
        /// <param name="Theme"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseAPIResult> AddTheme(ThemeDTO Theme)
        {
            await _themeService.SetGlobalTheme(Theme);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///Delete theme
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<BaseAPIResult> DeleteTheme([Required] int? id)
        {
            await _themeService.DeleteGlobalTheme(id.Value);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///Post Or Put gallery images
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPost("SetGallaryImages")]
        public async Task<BaseAPIResult> SetHomeImages(List<GalleryImageDTO> images)
        {
            await _themeService.SetGallaryImages(images);
            return BaseSuccessResponse();
        }

        /// <summary>
        ///Post Or Put sliders
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPost("SetSliderImages")]
        public async Task<BaseAPIResult> SetSliderImages(List<GalleryImageDTO> images)
        {
            await _themeService.SetSliderImages(images);
            return BaseSuccessResponse();
        }
    }
}