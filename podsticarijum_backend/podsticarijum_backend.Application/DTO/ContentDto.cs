namespace podsticarijum_backend.Application.DTO;

public class ContentDto
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ContentDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public ContentDto(
        long id, 
        string contentType, 
        string text, 
        string? additionalText)
    {
        Id = id;
        ContentType = contentType;
        Text = text;
        AdditionalText = additionalText;
    }

    public long Id { get; set; }

    public string ContentType { get; init; }

    public string Text { get; set; }

    public string? AdditionalText { get; set; }
}
