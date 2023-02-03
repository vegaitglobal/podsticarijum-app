using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class CategoryDtoExtensions
{
    public static Category ToDomainModel(this CategoryDto categoryDto)
    {
        ArgumentNullException.ThrowIfNull(categoryDto);

        return new Category(navMenuText: categoryDto.NavMenuText,
                            description: categoryDto.Description,
                            active: categoryDto.Active);
    }
}
