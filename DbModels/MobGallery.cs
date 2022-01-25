#nullable disable

namespace Meta.IntroApp
{
    public partial class MobGallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? IsFeatured { get; set; }
        public string MerchantId { get; set; }
        public int? BranchId { get; set; }
        public string Url { get; set; }
    }
}