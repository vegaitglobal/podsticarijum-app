using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class ExpertExtensions
{
    public static ExpertDto ToDto(this Expert expert)
        => new ExpertDto(
            subCategoryDto: expert.SubCategory.ToDto(),
            firstName: expert.FirstName,
            lastName: expert.LastName,
            email: expert.Email,
            description: expert.Description)
            {
                Id = expert.Id
            };

    public static List<ExpertDto> ToDto(this IEnumerable<Expert> experts)
        => experts.Select(e => e.ToDto()).ToList();

    public static ExpertInfoDto ToDto(this ExpertInfo expert)
        => new ExpertInfoDto(
             id: expert.Id,
             title: expert.Title,
             content: expert.Content
            );

    public static List<ExpertInfoDto> ToDto(this IEnumerable<ExpertInfo> expertInfoDtos)
        => expertInfoDtos.Select(ei => ei.ToDto()).ToList();
}
