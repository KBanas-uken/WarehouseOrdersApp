using Microsoft.AspNetCore.Identity.UI.Services;

namespace WarehouseOrdersApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Intentionally do nothing, to be able to use Idenitity, without having to send actual mails
            return Task.CompletedTask;
        }
    }
}
