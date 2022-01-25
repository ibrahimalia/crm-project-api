using Meta.IntroApp.DbModels;
using Meta.IntroApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Contacts
{
    public class PRJGetContactsDTO
    {
        public int Id { get; set; }
    
        public string PRJContactsName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Category { get; set; }
        public string Photo { get; set; }        
        public string AddressType { get; set; }
        public string JobPosition { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        
    }

    public class PRJContactProjectManagerDTO
    {
        public string FullName { get; set; }
        public string Photo { get; set; } 
        
    }
    public class DropdownsDataForAddcontactToProject 
    {
        public List<string> Projects { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Levels { get; set; }
    }

    public class DropdownsDataForAddcontact 
    {
        public List<string> JobPositions { get; set; }
        public List<string> AddressTypes { get; set; }
        public List<string> ContactsParents { get; set; }
    }
}
