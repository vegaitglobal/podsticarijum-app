using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IFaqRepository
{
    Task<List<Faq>> GetFaqsForCategory(long categoryId, bool tracking = false);

    Task<long> Insert(Faq faq);

    Task Update(Faq faq);

    Task Delete(Faq faq);
}
