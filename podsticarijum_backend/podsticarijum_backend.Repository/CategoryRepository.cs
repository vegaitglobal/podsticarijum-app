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

    public async Task<Category?> Get(long Id)
        => await _podsticarijumContext.Category.FindAsync(Id)
                                         .ConfigureAwait(false);

    public async Task<List<Category>> GetActive()
        => await _podsticarijumContext.Category.Where(c => c.Active == true).ToListAsync();

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
}
