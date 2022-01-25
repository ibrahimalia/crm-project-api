using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Localizations.Messages;
using Meta.IntroApp.DTOs.Contact;

//using Meta.IntroApp.Models;
using Meta.IntroApp.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientContactUsService : BaseService, IClientContactUs
    {
        public ClientContactUsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
             : base(context, httpContextAccessor)
        {
        }

        public async Task<ContactUSList> GetContactUs()
        {
            ContactUSList result = new ContactUSList();

            var contactUsList = await AppDbContext.Contacts.Where(x => x.MerchantId == CurrentMerchantId
                                                            && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId)
                                                            ).ToListAsync()
                                                            ;
            var contactsInfo = contactUsList.Where(x => x.Channel == ContactMethod.Address
                                                      || x.Channel == ContactMethod.Email
                                                      || x.Channel == ContactMethod.LocationOnMap
                                                      || x.Channel == ContactMethod.Phone).GroupBy(c => c.Channel)
                                .ToDictionary(c => c.Key, c => c.Select(val => val.Value));

            var socialContacts = contactUsList.Where(x => x.Channel == ContactMethod.Telegram
                                                    || x.Channel == ContactMethod.Twitter
                                                    || x.Channel == ContactMethod.WhatsApp
                                                    || x.Channel == ContactMethod.Facebook
                                                    || x.Channel == ContactMethod.Instagram).ToDictionary(c => c.Channel, c => c.Value);

            result.ContactMethods = contactsInfo;
            result.SocialContacts = socialContacts;
            return result;
        }
    }
}