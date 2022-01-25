using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Meta.IntroApp.Services.Utility.EventArguments;
using Meta.IntroApp.Services.Utility.Publisher;
using System;

namespace Meta.IntroApp.Services.Utility.subscriber
{
    public class NotificationSubscriber
    {

        public void Subscribe(NotificationPublisher pub)
        {
            pub.Arguments += SendNotification;
        }

        public void UnSubscribe(NotificationPublisher pub)
        {
            pub.Arguments -= SendNotification;
        }

        public void SendNotification(Object sender, NotificationArgument argument)
        {
            try
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("./IntegrationKeys/firebase-service-account.json")
                });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            var message = new Message()
            {
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = argument.Title,
                    Body = argument.Message,
                },
                Data = argument.Data,
                Topic = argument.Topic
            };
            try
            {
                var response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }


    }
}
