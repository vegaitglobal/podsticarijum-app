using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class ContentDtoExtensions
{
    public static Content ToDomainModel(this ContentDto contentDto)
    {
        ContentType contentTypeResult;
        bool contentTypeParsed = Enum.TryParse(contentDto.ContentType, out contentTypeResult);
        if (contentTypeParsed)
        {
            return new Content(contentTypeResult, contentDto.Text)
            {
                Id = contentDto.Id
            };
        }
        return new Content(contentType: ContentType.Default, contentDto.Text)
        {
            Id = contentDto.Id
        };
    }


    public static Content ToDomainModel(this ContentRequestDto contentDto)
    {
        ContentType contentTypeResult;
        bool contentTypeParsed = Enum.TryParse(contentDto.ContentType, out contentTypeResult);
        if (contentTypeParsed)
        {
            return new Content(contentTypeResult, contentDto.Text);
        }
        return new Content(contentType: ContentType.Default, contentDto.Text);
        
    }
}
