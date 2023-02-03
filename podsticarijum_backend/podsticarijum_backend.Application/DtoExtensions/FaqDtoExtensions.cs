using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class FaqDtoExtensions
{
    public static Faq ToDomainModel(this FaqDto faqDto)
        => new Faq(
            category: faqDto.CategoryDto.ToDomainModel(),
            question: faqDto.Question,
            answer: faqDto.Answer
            );
}
