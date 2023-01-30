namespace podsticarijum_backend.Domain;

public class EntityTimestamps
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
