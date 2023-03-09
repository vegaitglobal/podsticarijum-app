using Microsoft.AspNetCore.Mvc.Rendering;

namespace podsticarijum_backend.Api.Viewmodels;

public class FaqViewModel
{
    public long Id { get; set; }

    public IEnumerable<SelectListItem> SubCategoryDtoList { get; set; } = null!;

    public long SubCategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;
}
