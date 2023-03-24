using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class ExpertDtoExtensions
{
    public static Expert ToDomainModel(this ExpertDto expertDto)
    {
        ArgumentNullException.ThrowIfNull(expertDto);
        ArgumentNullException.ThrowIfNull(expertDto.SubCategoryDto);

        return new Expert(
            subCategory: expertDto.SubCategoryDto.ToDomainModel(),
            firstName: expertDto.FirstName,
            lastName: expertDto.LastName,
            email: expertDto.Email,
            description: expertDto.Description)
        { Id = expertDto.Id};
    }

    public static ExpertInfo ToDomainModel(this ExpertInfoRequestDto expertInfoRequestDto)
        => new
        ExpertInfo(
            title: expertInfoRequestDto.Title,
            content: expertInfoRequestDto.Content);
}
