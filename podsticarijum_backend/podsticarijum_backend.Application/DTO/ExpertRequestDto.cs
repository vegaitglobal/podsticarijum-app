using System.Text.Json.Serialization;

namespace podsticarijum_backend.Application.DTO;

public class ExpertRequestDto
{
    public ExpertRequestDto(SubCategoryDto? subCategoryDto, string firstName, string lastName, string email)
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
