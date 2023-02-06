using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using podsticarijum_backend.Application;
using podsticarijum_backend.Application.Options;

namespace podsticarijum_backend.Application.Services;

public class PodsticarijumMailService : IPodsticarijumMailService
{
    private readonly MailDataConfig _mailConfig;

    public PodsticarijumMailService(IOptions<MailDataConfig> mailConfig)
    {
        ArgumentNullException.ThrowIfNull(mailConfig);
        _mailConfig = mailConfig.Value;
        var mailAddressFrom = _mailConfig.AppMailAddressFrom ?? throw new ArgumentNullException(nameof(_mailConfig.AppMailAddressFrom));
        var emailHost = _mailConfig.Host ?? throw new ArgumentNullException(nameof(_mailConfig.Host));
        FromMailAddress = new(address: mailAddressFrom);

        NetworkCredential = new(_mailConfig.AppMailAddressFrom, _mailConfig.Password);
        Host = _mailConfig.Host;
        Port = _mailConfig.Port;
    }

    public string AppPackageName { get; set; } = "com.example.app_for_family_backup";
    public NetworkCredential NetworkCredential { get; }
    public MailAddress FromMailAddress { get; }
    private string Host { get; }
    private int Port { get; }


    public async Task sendEmail(string ToMailAddress, string subject, string body)
    {
        try
        {
            MailAddress mailAddressTo = new(ToMailAddress);
            var smtp = new SmtpClient
            {
                Host = Host,
                Port = Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = NetworkCredential
            };
            using var message = new MailMessage(FromMailAddress, mailAddressTo)
            {
                Subject = subject,
                Body = body
            };
            await smtp.SendMailAsync(message);
        }
        catch(Exception)
        {
            throw;
        }
        
    }

    private static void GuardValidEmail(string? email)
    {
        ArgumentNullException.ThrowIfNull(email);
    }

    private static void GuardValidAppPackageName(string? appPackageName)
    {
        ArgumentNullException.ThrowIfNull(appPackageName);

        var validAppPackageNames = new string[] { "com.example.app_for_family_backup", "" };

        if (!validAppPackageNames.Contains(appPackageName))
        {
            throw new ArgumentException($"Not a valid nameof{appPackageName}");
        }
    }
}