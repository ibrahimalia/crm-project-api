using Meta.IntroApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    

    public class MobRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //public int serviceId { get; set; }
        public int subServiceId { get; set; }
        public string Notes { get; set; }
        public string MerchantId { get; set; }
        public long? AccountsId { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Title { get; set; }
        public RequestStatus Status { get; set; }


        public virtual MobMerchant Merchant { get; set; }
        public virtual Account Accounts { get; set; }
        //public virtual MobService Service { get; set; }
        public virtual MobSubService SubService { get; set; }
    }
}
