using Meta.IntroApp.DTOs.Contact;

using System.Collections.Generic;

//using Meta.IntroApp.Models;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientContactUs
    {
        Task<ContactUSList> GetContactUs();

    }
}