#nullable disable

namespace Meta.IntroApp
{
    public enum ContactMethod
    {
        Phone = 1,
        Email = 2,
        Facebook = 3,
        Instagram = 4,
        Twitter = 5,
        Telegram = 6,
        LocationOnMap = 7,
        Address = 8,
        WhatsApp = 9
    }

    public partial class MobContact
    {
        public int ContactUsId { get; set; }
        public ContactMethod Channel { get; set; }
        public string Value { get; set; }
        public int? IsSelected { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public int? IsActive { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
    }
}