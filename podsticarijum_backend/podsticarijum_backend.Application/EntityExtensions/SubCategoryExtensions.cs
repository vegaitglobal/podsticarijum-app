using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
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
            active: subCategory.Active);

    public static List<SubCategoryDto> ToDto(this IEnumerable<SubCategory> subCategories)
        => subCategories.Select(sc => sc.ToDto()).ToList();
}
