using System;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobNews
    {
        public MobNews()
        {
            MobImages = new HashSet<MobImage>();
        }

        public int NewsId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime? PublishingDate { get; set; }
        public int? IsPublished { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public int? IsActive { get; set; }
        public string Images { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        public virtual ICollection<MobImage> MobImages { get; set; }
    }
}