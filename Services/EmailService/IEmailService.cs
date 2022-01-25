using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public interface IEmailService
    {
        Task SendAsync(string title, string htmlBody, string textBody, params EmailReceiver[] receivers);
    }
}