using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Notification;
using Meta.IntroApp.Services.Notification;
using Meta.IntroApp.Services.Utility.Publisher;
using Meta.IntroApp.Services.Utility.subscriber;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Areas.Admin.Controllers
{
    public class NotificationController : BaseAdminController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500)]
        public BaseAPIResult SendNotification(SendNotificationDTO notificationDTO)
        {
            bool sucess = _notificationService.SendNotification(notificationDTO);
            return SuccessResponse(sucess);
        }
    }
}
