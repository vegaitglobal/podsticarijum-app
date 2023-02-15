using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Repository;

public class FaqRepository : IFaqRepository
{
    private readonly PodsticarijumContext _podsticarijumContext = null!;

    public FaqRepository(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext;
    }

    public Task<List<Faq>> GetFaqsForCategory(long categoryId, bool tracking = false)
    {
        var query = _podsticarijumContext.Faq
                                    .Include(faq => faq.Category)
                                    .Where(faq => faq.Category.Id == categoryId);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(Faq faq)
    {
        _podsticarijumContext.Add(faq);
        await _podsticarijumContext.SaveChangesAsync().ConfigureAwait(false);
        return faq.Id;
    }

    public async Task Update(Faq faq)
    {
        _podsticarijumContext.Update(faq);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(Faq faq)
    {
        _podsticarijumContext.Remove(faq);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
