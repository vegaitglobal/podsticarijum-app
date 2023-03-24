using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IFaqRepository
{

    Task<Faq?> Get(long id, bool tracking = false);

    Task<List<Faq>> GetFaqsForCategory(long categoryId, bool tracking = false);

    Task<List<Faq>> GetAll(bool tracking = false);

    Task<long> Insert(Faq faq);

    Task Insert(IEnumerable<Faq> faq);

    Task Update(Faq faq);

    Task Delete(Faq faq);
}
