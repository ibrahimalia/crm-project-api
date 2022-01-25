using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs
{
    public class FeedBackDTO
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class GetFeedBackDTO
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long? AccountsId { get; set; }

    }
}
