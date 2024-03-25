using System.Net.Mail;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.Services
{
    public class MailService : IMailService
    {

        public async Task SendMail(Mail mail)
        {
        }
    }

    public interface IMailService
    {
        Task SendMail(Mail mail);
    }
}
