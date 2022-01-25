using Meta.IntroApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DbModels
{
    //public enum CategoryType
    //{
    //    Individual = 1 ,
    //    Company = 2
    //}
    public class PRJContacts
    {
        public PRJContacts()
        {
            Contacts = new HashSet<PRJContacts>();          
         //   ProjectFollowers = new HashSet<PRJProjectFollowers>();
           
        }
        public int Id{ get; set; }
        [ForeignKey("PRJContacts")]
        public int? PRJContactsId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public CategoryType? Category { get; set; }
        public string Photo{ get; set; }
        public int? AddressTypeId { get; set; }
        public int? PRJJobPositionId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Tags { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public string MobMerchantMerchantId { get; set; }
        public long? UserId { get; set; }
        public virtual ICollection<PRJContacts> Contacts { get; set; }

       // public virtual ICollection<PRJProjectFollowers> ProjectFollowers { get; set; }


        [ForeignKey("CreatedBy")]
        public virtual Account CreatedByAccount { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual Account UpdatedByAccount { get; set; }

        [ForeignKey("UserId")]
        public virtual Account User { get; set; }

        [ForeignKey("PRJJobPositionId")]
        public virtual PRJJobPosition JobPosition { get; set; }
        [ForeignKey("AddressTypeId")]
        public virtual PRJAddressType AddressType { get; set; }
        

    }
}
