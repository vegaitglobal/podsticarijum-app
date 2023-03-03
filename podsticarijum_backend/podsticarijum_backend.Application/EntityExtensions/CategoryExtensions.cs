using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category category)
        => new CategoryDto(
                           id: category.Id,
                           navMenuText: category.NavMenuText,
                           description: category.Description);


    public static CategoryFullDto ToFullDto(this Category category)
        => new CategoryFullDto(
                           id: category.Id,
                           navMenuText: category.NavMenuText,
                           description: category.Description)
        {
            SubCategories = category.SubCategories.ToDto()
        };

    public static List<CategoryDto> ToDto(this IEnumerable<Category> categories)
        => categories.Select(c => c.ToDto()).ToList();

    public static List<CategoryFullDto> ToFullDto(this IEnumerable<Category> categories)
        => categories.Select(c => c.ToFullDto()).ToList();
}
