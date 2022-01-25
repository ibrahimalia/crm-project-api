using Meta.IntroApp.DbModels;
using Meta.IntroApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Contacts
{
    public class PRJAddContactsDTO
    {
        public int? PRJContactsId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public CategoryType Category { get; set; }
        public string Photo { get; set; }
        public int AddressTypeId { get; set; }
        public int JobPositionId { get; set; }
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
        public int? IsArchive { get; set; }  
      
        //public long UserId { get; set; }
    }
}
