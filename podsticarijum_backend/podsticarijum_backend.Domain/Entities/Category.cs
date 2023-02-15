namespace podsticarijum_backend.Domain.Entities;

public class Category : EntityTimestamps
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Category()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public Category(string navMenuText, string description)
    {
        NavMenuText = navMenuText ?? throw new ArgumentNullException(nameof(navMenuText));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public long Id { get; set; }

    /// <summary>
    /// Navigation menu text (or other label)
    /// </summary>
    public string NavMenuText { get; set; }
    
    /// <summary>
    /// Currently unused, but can be used for hovers and any additional info
    /// </summary>
    public string Description { get; set; }
}
