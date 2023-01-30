namespace podsticarijum_backend.Domain.Entities;

public class MainScreen : EntityTimestamps
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected MainScreen()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public MainScreen(string content, string buttonText, bool active)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
        ButtonText = buttonText ?? throw new ArgumentNullException(nameof(buttonText));
        Active = active;
    }

    public long Id { get; set; }

    public string Content { get; set; }

    public string ButtonText { get; set; }

    public bool Active { get; set; }

}
