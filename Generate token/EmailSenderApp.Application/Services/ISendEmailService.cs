using EmailSenderApp.Domen.Entities.Models;

namespace EmailSenderApp.Application.Services
{
    public interface ISendEmailService
    {
        public Task SendEmailAsync(EmailModel emailModel);
    }
}
