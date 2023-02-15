namespace podsticarijum_backend.Application.DTO;

public class FaqDto
{
    public FaqDto(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public long Id { get; set; }

    public CategoryDto CategoryDto { get; set; }

    public string Question { get; set; }

    public string Answer { get; set; }
}
