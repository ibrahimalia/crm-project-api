namespace Meta.IntroApp.DTOs.Theme
{
    public class ThemeDTO
    {
        public bool MainSliderVisibilty { get; set; }
        public bool NewsSliderVisibility { get; set; }
        public bool ProjectSliderVisibilty { get; set; }
        public bool ServiceSliderVisibility { get; set; }
        public bool GallerySliderVisibility { get; set; }
        public string FontColor { get; set; }
        public string GlobalColor { get; set; }
        public string BackGroundColor { get; set; }
        public string FontType { get; set; }
        public string SideBarColor { get; set; }
        public string NavBarColor { get; set; }
        public string MerchantId { get; set; }
        public int? LayoutOrder { get; set; }
        //public int? IsActive { get; set; }
        public string ImageUrl { get; set; }
        public string SplashScreenTitle { get; set; }
        public string SplashScreenColor { get; set; }
        public string FontSize { get; set; }
    }
}