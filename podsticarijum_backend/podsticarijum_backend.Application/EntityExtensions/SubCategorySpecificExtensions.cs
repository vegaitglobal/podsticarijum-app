using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class SubCategorySpecificExtensions
{
    public static SubCategorySpecificDto ToDto(this SubCategorySpecificContent subCategorySpecificContent)
    => new SubCategorySpecificDto(
        id: subCategorySpecificContent.Id,
        subCategoryDto: subCategorySpecificContent.SubCategory.ToDto(),
        paragraphText: subCategorySpecificContent.ParagraphText,
        paragraphSign: subCategorySpecificContent.ParagraphSign);

    public static List<SubCategorySpecificDto?> ToDto(this IEnumerable<SubCategorySpecificContent> subCategorySpecificContents)
        => subCategorySpecificContents.Select(scc => scc?.ToDto()).ToList();
}