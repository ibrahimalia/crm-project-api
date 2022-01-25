using Meta.IntroApp.DTOs.PRJ_Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Contacts.admin
{
    public interface PRJIAdminContact
    {
        Task<List<PRJGetContactsDTO>> GetContacts();
        Task<List<PRJContactProjectManagerDTO>> GetDataPRojectManager();

        Task<PRJGetContactsDTO> GetContactDetailes(int id);
        Task AddContact(int adminId, PRJAddContactsDTO model);
        Task UpdateContact(int adminId, int id, PRJAddContactsDTO model);
        Task DeleteContact(int id);
        Task<DropdownsDataForAddcontactToProject> GetDropdownsDataForAddcontactToProject();
        Task<DropdownsDataForAddcontact> GetDropdownsDataForAddcontact();
    }
}
