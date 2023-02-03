using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podsticarijum_backend.Application.DTO;

public class FaqDto
{
    public FaqDto(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public CategoryDto CategoryDto { get; set; } = null!;
    public string Question { get; set; }

    public string Answer { get; set; }
}
