using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Services;
using Meta.IntroApp.Services.Admin;
using Meta.IntroApp.Services.Notification;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Client.Controllers.Client
{

    public class ThemeController : BaseClientController
    {
        //inject the repositories and dbcontext class

        private readonly IClientProjectService _projectService;
        private readonly IClientNewsService _newsService;
        private readonly IClientServicesService _servicesService;
        private readonly IClientThemeExecution _clientThemeService;
        private readonly IClientAboutUsService _aboutUsService;
        private readonly IClientSubServicesService subService;
        private readonly IAdminThemeService _theme;
        private readonly INotificationService _notification;

        public ThemeController(IClientProjectService projectService,
                                   IClientNewsService newsService
                                    , IClientAboutUsService aboutusService
                                    , IClientServicesService servicesService
                                    , IClientThemeExecution clientThemeService
                                    , IClientSubServicesService clientSubServicesService
                                    , IAdminThemeService theme
                                    , INotificationService notification
            )
        {
            this._projectService = projectService;
            this._newsService = newsService;
            this._servicesService = servicesService;
            this._clientThemeService = clientThemeService;
            this._aboutUsService = aboutusService;
            subService = clientSubServicesService;
            _theme = theme;
            _notification = notification;
        }

        /// <summary>
        /// Show Home Page
        /// </summary>
        /// <returns></returns>
        [HttpGet("HomePage")]
        [ProducesResponseType(statusCode: 200, Type = typeof(APIResult<HomePageDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(BaseAPIResult))]
        public async Task<BaseAPIResult> GetThemesHomePage()
        {

            var theme =await _theme.GetGlobalTheme();
            if (theme == null)
            {
                return ErrorResponse(404, "there is no theme for this merchant");
            }
            return SuccessResponse(new HomePageDTO
            {
                MainSliderVisibilty = theme.MainSliderVisibilty,
                GallerySliderVisibility = theme.GallerySliderVisibility,
                NewsSliderVisibility = theme.NewsSliderVisibility,
                ProjectSliderVisibilty = theme.ProjectSliderVisibilty,
                ServiceSliderVisibility = theme.ServiceSliderVisibility,

                Projects = await _projectService.GetProjects(new PaginationFilterDTO()
                {
                    PageNumber = 1,
                    PageSize = 5
                }),
                Services = await _servicesService.GetServices(),
                SubServices = await subService.GetAllSubServices(),
                Gallery = await _aboutUsService.GetHomePageImages(),
                Sliders = await _clientThemeService.GetSliders(),
                News = await _newsService.GetHomePageNews(),
                Topics = _notification.GetUserTopics()
            }); 
        }
    }
}