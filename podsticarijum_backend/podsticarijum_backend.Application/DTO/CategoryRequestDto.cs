using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace podsticarijum_backend.Application.DTO;

public class CategoryRequestDto
{
    public CategoryRequestDto()
    {

    }

    public CategoryRequestDto(string navMenuText, string description)
    {
        NavMenuText = navMenuText;
        Description = description;
    }

    [JsonIgnore]
    public long Id { get; set; }

    public string NavMenuText { get; set; } = null!;

    public string Description { get; set; } = null!;
}
