using Meta.IntroApp.DTOs.Contact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminContactUsService
    {
        Task AddOrUpdateContactUsList(Dictionary<ContactMethod, IEnumerable<string>> model, Dictionary<ContactMethod, string> socialContacts);
        Task<ContactUSList> GetContactUs();
    }
}