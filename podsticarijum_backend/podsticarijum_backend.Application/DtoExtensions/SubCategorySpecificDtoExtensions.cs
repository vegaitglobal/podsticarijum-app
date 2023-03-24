using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class SubCategorySpecificDtoExtensions
{
    public static SubCategorySpecificContent ToDomainModel(this SubCategorySpecificDto subCategorySpecificDto)
        => new SubCategorySpecificContent(
            subCategory: subCategorySpecificDto.SubCategoryDto.ToDomainModel(),
            paragraphText: subCategorySpecificDto.ParagraphText,
            paragraphSign: subCategorySpecificDto.ParagraphSign
            );
}
