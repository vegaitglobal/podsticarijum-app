using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class FaqExtensions
{
    public static FaqDto ToDto(this Faq faqEntity) 
        => new FaqDto(question: faqEntity.Question, answer: faqEntity.Answer);
}
