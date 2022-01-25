using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    public class PRJTimeSheet
    {
  
        public int Id { get; set; }
        public long? UserId  { get; set; }
        public DateTime? Day { get; set; }
        public int? FromHour { get; set; }
        public int? ToHour { get; set; }
        public int? FromMinute { get; set; }
        public int? ToMinute { get; set; }
        public int? Duration { get; set; }
        public int TaskId { get; set; }
        public string Notes { get; set; }
        public string MerchantID { get; set; }

        [ForeignKey("UserId")]
        public virtual Account User { get; set; }  

        [ForeignKey("TaskId")]
        public virtual PRJTask Task { get; set; } 
        [ForeignKey("MerchantID")]
        public virtual MobMerchant Merchant { get; set; }
    }
}
