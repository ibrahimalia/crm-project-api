using System;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobProject
    {
        public MobProject()
        {
            MobImages = new HashSet<MobImage>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public DateTime? EndDate { get; set; }
        public string Period { get; set; }
        public int? IsActive { get; set; }
        public string Images { get; set; }
        public string ClientName { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        public virtual ICollection<MobImage> MobImages { get; set; }
    }
}