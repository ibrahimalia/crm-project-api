using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.Contact
{
    public class AddOrUpdateContactDTO
    {
        public Dictionary<ContactMethod, IEnumerable<string>> ContactMethods { set; get; }
    }

    public class ContactUSList
    {
        public Dictionary<ContactMethod, IEnumerable<string>> ContactMethods { set; get; }
        public Dictionary<ContactMethod, string> SocialContacts { set; get; }
    }





    public class SocialMedia
    {
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Telegram { get; set; }
        public string WhatsApp { get; set; }

    }

}