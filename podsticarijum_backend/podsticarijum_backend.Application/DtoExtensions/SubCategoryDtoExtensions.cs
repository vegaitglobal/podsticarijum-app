using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class SubCategoryDtoExtensions
{
    public static SubCategory ToDomainModel(this SubCategoryRequestDto subCategoryDto)
    {
        ArgumentNullException.ThrowIfNull(subCategoryDto);
        ArgumentNullException.ThrowIfNull(subCategoryDto.CategoryDto);

        return new SubCategory(
            category: subCategoryDto.CategoryDto.ToDomainModel(),
            mainNavMenuText: subCategoryDto.MainNavMenuText,
            mainText: subCategoryDto.MainText,
            additionalText: subCategoryDto.AdditionalText,
            checkMoreButtonText: subCategoryDto.CheckMoreButtonText,
            checkMorePageTitle: subCategoryDto.CheckMorePageTitle,
            checkMorePageText: subCategoryDto.CheckMorePageText,
            developmentSupportingActivitiesButtonText: subCategoryDto.DevelopmentSupportingActivitiesButtonText,
            atypicalDevelopmentSignsText: subCategoryDto.AtypicalDevelopmentSignsText,
            greenActivityPageTitle: subCategoryDto.GreenActivityPageTitle,
            redActivityPageTitle: subCategoryDto.RedActivityPageTitle,
            active: subCategoryDto.Active);
    }

    public static SubCategory ToDomainModel(this SubCategoryDto subCategoryDto)
    {
        ArgumentNullException.ThrowIfNull(subCategoryDto);
        ArgumentNullException.ThrowIfNull(subCategoryDto.CategoryDto);

        return new SubCategory(
            category: subCategoryDto.CategoryDto.ToDomainModel(),
            mainNavMenuText: subCategoryDto.MainNavMenuText,
            mainText: subCategoryDto.MainText,
            additionalText: subCategoryDto.AdditionalText,
            checkMoreButtonText: subCategoryDto.CheckMoreButtonText,
            checkMorePageTitle: subCategoryDto.CheckMorePageTitle,
            checkMorePageText: subCategoryDto.CheckMorePageText,
            developmentSupportingActivitiesButtonText: subCategoryDto.DevelopmentSupportingActivitiesButtonText,
            atypicalDevelopmentSignsText: subCategoryDto.AtypicalDevelopmentSignsText,
            greenActivityPageTitle: subCategoryDto.GreenActivityPageTitle,
            redActivityPageTitle: subCategoryDto.RedActivityPageTitle,
            active: subCategoryDto.Active)
        { Id = subCategoryDto.Id };
    }
}
