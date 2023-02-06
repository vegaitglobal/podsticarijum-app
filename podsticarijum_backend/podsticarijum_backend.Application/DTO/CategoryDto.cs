using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace podsticarijum_backend.Application.DTO;

public class CategoryDto
{
    public CategoryDto(string navMenuText, string description, bool active)
    {
        NavMenuText = navMenuText;
        Description = description;
        Active = active;
    }

    [JsonIgnore]
    public long Id { get; set; }

    public string NavMenuText { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}
