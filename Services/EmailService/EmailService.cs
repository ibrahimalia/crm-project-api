
using MailKit.Net.Smtp;

using Meta.IntroApp.Localizations.Tokens;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MimeKit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class EmailReceiver
    {
        public EmailReceiver(string email, string name = null)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = string.IsNullOrEmpty(name) ? email : name;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
    public class EmailService : BaseService, IEmailService
    {
        private readonly IConfiguration _configurations;

        public EmailService(IHttpContextAccessor httpContextAccessor, MetaITechDbContext dbContext, IConfiguration configService) : base(dbContext, httpContextAccessor)
        {
            this._configurations = configService;
        }

        public async Task SendAsync(string title, string htmlBody, string textBody, params EmailReceiver[] receivers)
        {
            for (int retryCounter = 0; retryCounter < 5; retryCounter++)
            {
                try
                {
                    //getting configurations
                    var emailConfigurationSEction = _configurations.GetSection("MailSettings");
                    var smtpServerIp = emailConfigurationSEction.GetValue<string>("SMTPEmailAddress");
                    var smtpServerPort = emailConfigurationSEction.GetValue<int>("SMTPEmailPort");
                    var serverEmail = emailConfigurationSEction.GetValue<string>("SenderEmailAddress");
                    var serverEmailPassword = emailConfigurationSEction.GetValue<string>("EmailPassword");
                    var sslEnabled = emailConfigurationSEction.GetValue<bool>("EnableSSL");

                    var message = new MimeMessage();

                    var from = new MailboxAddress(Tokens.SystemName, serverEmail);
                    message.From.Add(from);

                    //Adding Receivers
                    receivers.Where(c => !string.IsNullOrEmpty(c.Email))
                                                 .ToList()
                                                 .ForEach(c => message.To.Add(new MailboxAddress(c.Name ?? c.Email, c.Email)))
                                                 ;

                    message.Subject = title;
                    message.Body = new BodyBuilder
                    {
                        HtmlBody = htmlBody,
                        TextBody = textBody
                    }.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    await client.ConnectAsync(smtpServerIp, smtpServerPort, sslEnabled);
                    client.Authenticate(serverEmail, serverEmailPassword);


                    //sending the message
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    client.Dispose();

                    //ok sent successfully then stop retrying
                    break;
                }
                catch (Exception ex)
                {
                    Logger.LogCritical(ex, "Could Not Send Email At " + DateTime.Now);
                    Thread.Sleep(1500);
                }
            }
        }
    }
}