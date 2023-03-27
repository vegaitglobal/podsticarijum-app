using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class ContentExtensions
{
    public static ContentDto ToDto(this Content content)
        => new(
            id: content.Id, 
            contentType: content.ContentType.ToString(), 
            text: content.Text,
            additionalText: content.AdditionalText);

    public static List<ContentDto> ToDto(this List<Content> contentList)
        => contentList.Select(c => c.ToDto()).ToList();
}
