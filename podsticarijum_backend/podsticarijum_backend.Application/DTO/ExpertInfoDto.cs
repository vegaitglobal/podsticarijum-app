namespace podsticarijum_backend.Application.DTO;

public class ExpertInfoDto
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ExpertInfoDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public ExpertInfoDto(long id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}
