using AppointmentManagementSystem.Application.Interfaces.ExternalServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AppointmentManagementSystem.Infrastructure.Settings;

public class MailKitEmailService : IEmailService
{
    private readonly MailSettings _mailSettings;

    public MailKitEmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress(
            _mailSettings.SenderName,
            _mailSettings.SenderEmail));

        email.To.Add(MailboxAddress.Parse(to));

        email.Subject = subject;

        email.Body = new TextPart("html")
        {
            Text = body
        };

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            _mailSettings.Server,
            _mailSettings.Port,
            SecureSocketOptions.StartTls);

        await smtp.AuthenticateAsync(
            _mailSettings.UserName,
            _mailSettings.Password);

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}