using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.Notification
{
    public class SendNotificationDTO
    {
        public string NotificationMessage { get; set; }
        public string Title { get; set; }
        public TopicEnum Topic { get; set; }
        public Dictionary<string,string> Data { get; set; }
    }
}
