using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class SubCategoryExtensions
{
    public static SubCategoryDto ToDto(this SubCategory subCategory)
        => new SubCategoryDto(
            id: subCategory.Id,
            categoryDto: subCategory.Category.ToDto(),
            mainNavMenuText: subCategory.MainNavMenuText,
            mainText: subCategory.MainText,
            additionalText: subCategory.AdditionalText,
            checkMoreButtonText: subCategory.CheckMoreButtonText,
            checkMorePageTitle: subCategory.CheckMorePageTitle,
            checkMorePageText: subCategory.CheckMorePageText,
            developmentSupportingActivitiesButtonText: subCategory.DevelopmentSupportingActivitiesButtonText,
            atypicalDevelopmentSignsText: subCategory.AtypicalDevelopmentSignsText,
            greenActivityPageTitle: subCategory.GreenActivityPageTitle,
            redActivityPageTitle: subCategory.RedActivityPageTitle,
            active: subCategory.Active);

    public static List<SubCategoryDto> ToDto(this IEnumerable<SubCategory> subCategories)
        => subCategories.Select(sc => sc.ToDto()).ToList();

    public static void UpdateFromDto(
        this SubCategory subCategory,
        SubCategoryDto subCategoryDto
        )
    {
        subCategory.MainNavMenuText = subCategoryDto.MainNavMenuText;
        subCategory.MainText = subCategoryDto.MainText;
        subCategory.AdditionalText = subCategoryDto.AdditionalText;
        subCategory.CheckMoreButtonText = subCategoryDto.CheckMoreButtonText;
        subCategory.CheckMorePageTitle = subCategoryDto.CheckMorePageTitle;
        subCategory.CheckMorePageText = subCategoryDto.CheckMorePageText;
        subCategory.Active = subCategoryDto.Active;
        subCategory.DevelopmentSupportingActivitiesButtonText = subCategoryDto.DevelopmentSupportingActivitiesButtonText;
        subCategory.AtypicalDevelopmentSignsText = subCategoryDto.AtypicalDevelopmentSignsText;
        subCategory.GreenActivityPageTitle = subCategoryDto.GreenActivityPageTitle;
        subCategory.RedActivityPageTitle = subCategoryDto.RedActivityPageTitle;
    }

}
