using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.JWT;
using Meta.IntroApp.DTOs.Notification;
using Meta.IntroApp.Services.Utility.Publisher;
using Meta.IntroApp.Services.Utility.subscriber;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Notification
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(MetaITechDbContext dbcontext,  IHttpContextAccessor httpContextAccessor) 
            : base(dbcontext, httpContextAccessor)
        {

        }
        public List<string> GetUserTopics()
        {
            List<string> topics = new List<string>();
            topics.Add("General_" + CurrentMerchantId);
            topics.Add("Marketing_" + CurrentMerchantId);
            topics.Add(CurrentUserId+"");
            return topics;
        }

        public bool SendNotification(SendNotificationDTO notificationDTO)
        {
            try
            {

                NotificationPublisher pub = new NotificationPublisher();
                NotificationSubscriber sub = new NotificationSubscriber();
                sub.Subscribe(pub);
                pub.Notify(notificationDTO.NotificationMessage, notificationDTO.Title, notificationDTO.Topic.ToString(), notificationDTO.Data);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
