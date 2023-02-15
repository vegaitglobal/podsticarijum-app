using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Repository;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly PodsticarijumContext _podsticarijumContext;
    public SubCategoryRepository(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext;
    }

    public Task<SubCategory?> Get(long id, bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategory.Where(sc => sc.Id == id)
                                                     .Include(sc => sc.Category);

        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }

    public Task<List<SubCategory>> GetAll(bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategory.Include(sc => sc.Category);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }
    
    public Task<List<SubCategory>> GetForCategory(long categoryId, bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategory
                                                .Include(sc => sc.Category)
                                                .Where(sc => sc.Category.Id == categoryId);

        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(SubCategory subCategory)
    {
        _podsticarijumContext.Add(subCategory);
        await _podsticarijumContext.SaveChangesAsync().ConfigureAwait(false);
        return subCategory.Id;
    }

    public async Task Update(SubCategory subCategory)
    {
        _podsticarijumContext.Update(subCategory);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(SubCategory subCategory)
    {
        _podsticarijumContext.Remove(subCategory);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
