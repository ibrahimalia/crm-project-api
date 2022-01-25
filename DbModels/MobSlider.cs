#nullable disable

namespace Meta.IntroApp
{
    public partial class MobSlider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int? IsFeatured { get; set; }
        public string MerchantId { get; set; }
        public int? BranchId { get; set; }
    }
}