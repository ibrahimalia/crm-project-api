#nullable disable

namespace Meta.IntroApp
{
    public partial class MobAbout
    {
        public int AboutUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string MerchantId { get; set; }
        public string Images { get; set; }

        public virtual MobMerchant Merchant { get; set; }
    }
}