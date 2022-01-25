using MailKit.Net.Smtp;
using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Meta.IntroApp.Services.FeedBack
{
    public class ClientFeedBackEmail : BaseService, IClientFeedBackEmail
    {
        private readonly IConfiguration _config;
        public ClientFeedBackEmail(IHttpContextAccessor httpContextAccessor, MetaITechDbContext dbContext, IConfiguration configService) : base(dbContext, httpContextAccessor)
        {
           _config = configService;
        }

        public async Task<List<GetFeedBackDTO>> GetFeedBacks()
        {
            var result = await AppDbContext.FeedBacks.Where(x => x.MerchantId == CurrentMerchantId).ToListAsync();
            return result?.ConvertAll(feedBack => new GetFeedBackDTO
            {
                Email = feedBack.Email,
                AccountsId = feedBack.AccountsId,
                Message = feedBack.Message,
                Phone = feedBack.Phone,
                Sender = feedBack.SenderName
            });
        }

        public async Task SendEmailAsync(long? clientID, FeedBackDTO feedBack)
        {
            try
            {
                //store feedBack in database
                var ClientFeedBack = new MobFeedBack
                {
                    Message = feedBack.Message,
                    Email = feedBack.Email,
                    AccountsId = clientID,
                    MerchantId = CurrentMerchantId,
                    SenderName = feedBack.Sender,
                    Phone = feedBack.Phone,                   
                };

                await AppDbContext.FeedBacks.AddAsync(ClientFeedBack);
                await AppDbContext.SaveChangesAsync();


                //get email configuration
                var emailConfigurationSEction = _config.GetSection("MailSettings");
                var smtpServerIp = emailConfigurationSEction.GetValue<string>("SMTPEmailAddress");
                var smtpServerPort = emailConfigurationSEction.GetValue<int>("SMTPEmailPort");
                var serverEmail = emailConfigurationSEction.GetValue<string>("SenderEmailAddress");
                var serverEmailPassword = emailConfigurationSEction.GetValue<string>("EmailPassword");
           


                MimeMessage _message = new MimeMessage();
                //sender
                MailboxAddress from = new MailboxAddress("sender", serverEmail);

                _message.From.Add(from);

                var MerchantEmail = await AppDbContext.Merchants.Where(x => x.MerchantId == CurrentMerchantId).Select(y => y.Email)
                                                                .FirstOrDefaultAsync();
                MailboxAddress to = new MailboxAddress("reciever", MerchantEmail);
                _message.To.Add(to);
                
             
                _message.Subject = "FeedBack";

                BodyBuilder bodyBuilder = new BodyBuilder();

                //bodyBuilder.HtmlBody = "<h1></h1>";
                bodyBuilder.TextBody = feedBack.Message;
                //bodyBuilder.Attachments.Add(attachement);
                _message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();

              await client.ConnectAsync(smtpServerIp, smtpServerPort, true);

                client.Authenticate(serverEmail, serverEmailPassword);

                await client.SendAsync(_message);

                await client.DisconnectAsync(true);
                client.Dispose();
               
            }
            catch (Exception)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }
        }
    }
}
