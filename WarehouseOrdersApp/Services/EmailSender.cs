using Microsoft.AspNetCore.Identity.UI.Services;

namespace WarehouseOrdersApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Intentionally do nothing
            return Task.CompletedTask;
        }
    }
}
