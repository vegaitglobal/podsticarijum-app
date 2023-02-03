using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly PodsticarijumContext _podsticarijumContext;

    public CategoryRepository(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext;
    }

    public Task<Category?> Get(long id, bool tracking = false)
    {
        var query = _podsticarijumContext.Category.Where(c => c.Id == id);
        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }

    public Task<List<Category>> GetActive(bool tracking = false)
    {
        var query = _podsticarijumContext.Category.Where(c => c.Active == true);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(Category category)
    {
        _podsticarijumContext.Add(category);
        await _podsticarijumContext.SaveChangesAsync();
        return category.Id;
    }

    public async Task Update(Category category)
    {
        _podsticarijumContext.Update(category);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _podsticarijumContext.Remove(category);
        await _podsticarijumContext.SaveChangesAsync();
    }   
}
