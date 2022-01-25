using Meta.IntroApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.FeedBack
{
   public interface IClientFeedBackEmail
    {
        Task SendEmailAsync(long? clientID , FeedBackDTO feedBack);
        Task<List<GetFeedBackDTO>> GetFeedBacks();
    }
}
