using System.Text.Json.Serialization;

namespace podsticarijum_backend.Application.DTO;

public class ContentRequestDto
{
    public ContentRequestDto(string contentType, string text, string? additionalText)
    {
        ContentType = contentType;
        Text = text;
        AdditionalText = additionalText;
    }

    [JsonIgnore]
    public long Id { get; init; }

    public string ContentType { get; init; }

    public string Text { get; set; }

    public string? AdditionalText { get; set; }
}
