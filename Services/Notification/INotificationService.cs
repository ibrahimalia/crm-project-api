using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.JWT;
using Meta.IntroApp.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Notification
{
    public interface INotificationService
    {
        public bool SendNotification(SendNotificationDTO notificationDTO);

        public List<string> GetUserTopics();
    }
}
