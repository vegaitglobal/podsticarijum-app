namespace podsticarijum_backend.Application.DTO;
public class MailDto
{
    public MailDto(string appPackageName, string userMailAddress, string subject, string body)
    {
        AppPackageName = appPackageName ?? throw new ArgumentNullException(nameof(appPackageName));
        UserMailAddress = userMailAddress ?? throw new ArgumentNullException(nameof(userMailAddress));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        Body = body ?? throw new ArgumentNullException(nameof(body));
    }

    public string AppPackageName { get; set; }

    public string UserMailAddress { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}

