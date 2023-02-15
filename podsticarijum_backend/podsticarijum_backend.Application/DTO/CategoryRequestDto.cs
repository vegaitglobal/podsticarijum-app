using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace podsticarijum_backend.Application.DTO;

public class CategoryRequestDto
{
    public CategoryRequestDto(string navMenuText, string description)
    {
        NavMenuText = navMenuText;
        Description = description;
    }

    [JsonIgnore]
    public long Id { get; set; }

    public string NavMenuText { get; set; }

    public string Description { get; set; }
}
