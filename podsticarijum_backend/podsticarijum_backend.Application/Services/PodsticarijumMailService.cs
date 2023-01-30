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
        FromMailAddress = new(_mailConfig.AppMailAddressFrom);

        NetworkCredential = new(_mailConfig.AppMailAddressFrom, _mailConfig.Password);
        Host = _mailConfig.Host;
        Port = _mailConfig.Port;
    }

    public string? Body { get; set; }
    public string? Subject { get; set; }
    public string? FromName { get; }
    public string? ToName { get; }
    public string? AppPackageName { get; set; }
    public NetworkCredential NetworkCredential { get; }
    public MailAddress FromMailAddress { get; }
    private string? Host { get; }
    private int Port { get; }


    public async Task sendEmail(string ToMailAddress)
    {
        try
        {
            GuardValidEmail(ToMailAddress);
            GuardValidAppPackageName(AppPackageName);
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
                Subject = Subject,
                Body = Body
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