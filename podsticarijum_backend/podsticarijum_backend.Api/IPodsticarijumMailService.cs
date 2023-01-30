namespace podsticarijum_backend;

public interface IPodsticarijumMailService
{
    Task sendEmail(string mailAddressTo);

    public string? Body { get; set; }
    public string? Subject { get; set; }
    public string? FromName { get; }
    public string? ToName { get; }
    public string? AppPackageName { get; set; }
}

