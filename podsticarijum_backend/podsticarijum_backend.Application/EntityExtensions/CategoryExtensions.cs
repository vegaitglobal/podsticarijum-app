﻿using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category category)
        => new CategoryDto(navMenuText: category.NavMenuText,
                        description: category.Description,
                        active: category.Active);

    public static List<CategoryDto> ToDto(this IEnumerable<Category> categories)
        => categories.Select(c => c.ToDto()).ToList();
}