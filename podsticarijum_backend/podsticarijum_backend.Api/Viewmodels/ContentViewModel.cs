using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain;

namespace podsticarijum_backend.Api.Viewmodels;

public class ContentViewModel
{
    public IEnumerable<SelectListItem> ContentTypeList { get; set; } = null!;

    public ContentType ContentType { get; set; }

    public string Content { get; set; } = null!;
}