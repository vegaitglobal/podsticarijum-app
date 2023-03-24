namespace podsticarijum_backend.Application.DTO;

public class ExpertInfoRequestDto
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ExpertInfoRequestDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
    public ExpertInfoRequestDto(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; set; }

    public string Content { get; set; }
}
