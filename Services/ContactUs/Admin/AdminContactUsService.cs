using Meta.IntroApp.DTOs.Contact;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminContactUsService : BaseService, IAdminContactUsService
    {
        public AdminContactUsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
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
                                                      ||x.Channel == ContactMethod.Email
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
        public async Task AddOrUpdateContactUsList(Dictionary<ContactMethod, IEnumerable<string>> model, Dictionary<ContactMethod, string> socialContacts)
        {
            AppDbContext.Contacts.RemoveRange(AppDbContext.Contacts.Where(c=> c.MerchantId == CurrentMerchantId).ToList());
            await AppDbContext.Contacts.AddRangeAsync(model.SelectMany(x => x.Value.Select(value => new MobContact
            {
                IsActive = 1,
                Channel = x.Key,
                BranchId = CurrentBranchId,
                MerchantId = CurrentMerchantId,
                IsSelected = 0,
                Value = value,
            })));
            await AppDbContext.Contacts.AddRangeAsync(socialContacts.Select(x => new MobContact
            {
                IsActive = 1,
                Channel = x.Key,
                BranchId = CurrentBranchId,
                MerchantId = CurrentMerchantId,
                IsSelected = 0,
                Value =x.Value,
            }));

            await AppDbContext.SaveChangesAsync();
        }
    }
}