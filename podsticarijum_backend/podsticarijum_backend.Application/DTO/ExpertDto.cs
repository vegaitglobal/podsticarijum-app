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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ExpertDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public ExpertDto(
        SubCategoryDto? subCategoryDto, 
        string firstName, 
        string lastName, 
        string email,
        string description)
    {
        SubCategoryDto = subCategoryDto;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Description = description;
    }

    public long Id { get; set; }

    [JsonIgnore]
    public SubCategoryDto? SubCategoryDto { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Description { get; set; }
}
