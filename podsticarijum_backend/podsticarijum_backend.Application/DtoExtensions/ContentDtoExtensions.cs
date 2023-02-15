using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class ContentDtoExtensions
{
    public static Content ToDomainModel(this ContentDto contentDto)
        => new Content(id: contentDto.Id, contentType: contentDto.ContentType, text: contentDto.Text);

    public static Content ToDomainModel(this ContentRequestDto contentDto)
        => new(id: contentDto.Id, contentType: contentDto.ContentType, text: contentDto.Text);
}
