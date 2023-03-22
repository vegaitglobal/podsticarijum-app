using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace podsticarijum_backend.Api.Viewmodels;

public class ExpertViewModel
{
    public IEnumerable<SelectListItem> SubCategoryList { get; set; } = null!;

    public long SubCategoryId { get; set; }

    public string FirstName { get; set; } = string.Empty!;

    public string LastName { get; set; } = string.Empty!;

    public string Email { get; set; } = null!;

    public string Description { get; set; } = null!;
}
