#nullable disable

namespace Meta.IntroApp
{
    public partial class MobGlobalTheme
    {
        public int MobGlobalThemeId { get; set; }
        public string FontColor { get; set; }
        public string GlobalColor { get; set; }
        public string BackGroundColor { get; set; }
        public string FontType { get; set; }
        public string SideBarColor { get; set; }
        public string NavBarColor { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public int? LayoutOrder { get; set; }
        //public int? IsActive { get; set; }
        public string LogoImage { get; set; }
        public bool MainSlider { get; set; }
        public bool ServicesSlider { get; set; }
        public bool ProjectSlider { get; set; }
        public bool NewsSlider { get; set; }
        public bool GallerySlider { get; set; }
        public string SplashScreenTitle { get; set; }
        public string SplashScreenColor { get; set; }
        public string FontSize { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
    }
}