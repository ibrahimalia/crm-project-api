using Meta.IntroApp.DTOs.News;
using Meta.IntroApp.DTOs.service;
using Meta.IntroApp.DTOs.SubService;

using System.Collections.Generic;

namespace Meta.IntroApp.DTOs
{
    public class HomePageDTO
    {
        public bool MainSliderVisibilty { get; set; }
        public bool NewsSliderVisibility { get; set; }
        public bool ProjectSliderVisibilty { get; set; }
        public bool ServiceSliderVisibility { get; set; }
        public bool GallerySliderVisibility { get; set; }
        public IEnumerable<GalleryImageDTO> Sliders { get; set; }
        public IEnumerable<ServiceDTO> Services { get; set; }
        public IEnumerable<ProjectDTO> Projects { get; set; }
        public IEnumerable<UpdateSubServiceDTO> SubServices { get; set; }
        public IEnumerable<GalleryImageDTO> Gallery { get; set; }
        public IEnumerable<GetNewsDTO> News { get; set; }
        public List<string> Topics { get; set; }
    }
}