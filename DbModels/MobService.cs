using Meta.IntroApp.DbModels;
using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobService
    {
        public MobService()
        {
       
            MobSubServices = new HashSet<MobSubService>();
            //MobRequest = new HashSet<MobRequest>();
        }

        public int ServicesId { get; set; }
        public string Title { get; set; }      
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public bool? IsActive { get; set; }
        public string IconMobile { get; set; }
        public string Image { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        
        public virtual ICollection<MobSubService> MobSubServices { get; set; }
        //public virtual ICollection<MobRequest> MobRequest { get; set; }
    }
}