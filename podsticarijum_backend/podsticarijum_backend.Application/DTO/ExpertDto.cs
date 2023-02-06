using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DTO;

public class ExpertDto
{
    public ExpertDto(SubCategoryDto? subCategoryDto, string firstName, string lastName, string email)
    {
        SubCategoryDto = subCategoryDto;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    [JsonIgnore]
    public long Id { get; set; }

    [JsonIgnore]
    public SubCategoryDto? SubCategoryDto { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
