
namespace podsticarijum_backend.Application.DTO;

public class FaqDto
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FaqDto()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public FaqDto(long id, SubCategoryDto subCategoryDto, string question, string answer)
    {
        Id = id;
        SubCategoryDto = subCategoryDto;
        Question = question;
        Answer = answer;
    }

    public long Id { get; set; }

    public SubCategoryDto SubCategoryDto { get; set; } = null!;

    public string Question { get; set; }

    public string Answer { get; set; }
}
