#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Application.DTO;

namespace podsticarijum_backend.Api.Viewmodels;

public class SubCategorySpecificViewModel
{
    public IEnumerable<SelectListItem> SubCategoryDtoList { get; set; }

    public long SubCategoryId { get; set; }

    public string PageTitle { get; set; }

    public string ParagraphText { get; set; }

    public IEnumerable<SelectListItem> ParagraphSigns { get; set; }

    public string ParagraphSign { get; set; }

    public SubCategorySpecificDto SubCategoryDto { get; set; }
}
