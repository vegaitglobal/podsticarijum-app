namespace podsticarijum_backend.Application;

public interface IPodsticarijumMailService
{
    Task sendEmail(string ToMailAddress, string subject, string body);

    public string AppPackageName { get; set; }
}

