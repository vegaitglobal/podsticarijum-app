using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Repository;

public class ExpertRepository : IExpertRepository
{
    private readonly PodsticarijumContext _podsticarijumContext;

    public ExpertRepository(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext ?? throw new ArgumentNullException(nameof(podsticarijumContext));
    }

    public Task<Expert?> Get(long expertId, bool tracking = false)
    {
        var query = _podsticarijumContext.Expert.Where(e => e.Id == expertId)
                                       .Include(e => e.SubCategory)
                                       .Include(e => e.SubCategory.Category);
        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }

    public Task<List<Expert>> GetAll(bool tracking = false)
    {

        var query = _podsticarijumContext.Expert.Include(e => e.SubCategory)
                                                .Include(e => e.SubCategory.Category);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();

    }

    public Task<Expert?> GetExpertForSubCategory(long subCategoryId, bool tracking = false)
    {
        var query = _podsticarijumContext.Expert.Include(e => e.SubCategory)
                                       .Include(e => e.SubCategory.Category)
                                       .Where(e => e.SubCategory.Id == subCategoryId);
        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<long> Insert(Expert expert)
    {
        _podsticarijumContext.Add(expert);
        await _podsticarijumContext.SaveChangesAsync();
        return expert.Id;
    }

    public async Task Update(Expert expert)
    {
        _podsticarijumContext.Update(expert);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(Expert expert)
    {
        _podsticarijumContext.Remove(expert);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
