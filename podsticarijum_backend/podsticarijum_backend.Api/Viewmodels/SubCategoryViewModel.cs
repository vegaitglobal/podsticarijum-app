using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Application.DTO;

namespace podsticarijum_backend.Api.Viewmodels;

public class SubCategoryViewModel
{
    public IEnumerable<SelectListItem> CategoryDtoList { get; set; } = null!;

    public long CategoryId { get; set; }

    public SubCategoryDto SubCategoryDto { get; set; } = null!;
}