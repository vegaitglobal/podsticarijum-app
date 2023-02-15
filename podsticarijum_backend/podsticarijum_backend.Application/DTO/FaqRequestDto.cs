using System.Text.Json.Serialization;

namespace podsticarijum_backend.Application.DTO;

public class FaqRequestDto
{
    public FaqRequestDto(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public string Question { get; set; }

    public string Answer { get; set; }
}
