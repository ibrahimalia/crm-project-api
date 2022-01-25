using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class MobFeedBack
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long? AccountsId { get; set; }
        public string MerchantId { get; set; }

        public virtual MobMerchant Merchant { get; set; }
        public virtual Account Accounts { get; set; }
    }
}
