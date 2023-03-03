using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class ContentDtoExtensions
{
    public static Content ToDomainModel(this ContentDto contentDto)
        => new Content(contentType: contentDto.ContentType, text: contentDto.Text)
        {
            Id = contentDto.Id
        };

    public static Content ToDomainModel(this ContentRequestDto contentDto)
        => new(contentType: contentDto.ContentType, text: contentDto.Text);
}
