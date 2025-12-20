using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string From { get; set; }
}

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _settings;

    public EmailSender(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
            EnableSsl = _settings.EnableSSL
        };

        var mail = new MailMessage
        {
            From = new MailAddress(_settings.From),
            Subject = subject,
            Body = body,
            IsBodyHtml = false
        };

        mail.To.Add(to);

        await client.SendMailAsync(mail);
    }
}
