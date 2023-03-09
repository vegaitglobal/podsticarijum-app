using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class FaqExtensions
{
    public static FaqDto ToDto(this Faq faqEntity) 
        => new FaqDto(
            id : faqEntity.Id,
            faqEntity.SubCategory.ToDto(),
            question: faqEntity.Question, 
            answer: faqEntity.Answer);

    public static List<FaqDto> ToDto(this IEnumerable<Faq> faqEntities)
        => faqEntities.Select(f => f.ToDto()).ToList();
}
