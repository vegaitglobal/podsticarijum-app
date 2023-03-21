using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain;
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

    public Task<List<SubCategorySpecificContent>> GetSubCategorySpecificForSubCategory(long subCategoryId, ParagraphSign paragraphSign = ParagraphSign.Default, bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategorySpecificContent
            .Include(sc => sc.SubCategory)
            .Where(sc => sc.SubCategory.Id == subCategoryId);

        if (paragraphSign != ParagraphSign.Default)
        {
            query = query.Where(sc => sc.ParagraphSign == paragraphSign);
        }

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

    public async Task Update(SubCategorySpecificContent content)
    {
        _podsticarijumContext.Update(content);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(SubCategory subCategory)
    {
        _podsticarijumContext.Remove(subCategory);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(SubCategorySpecificContent subCategorySpecificContent)
    {
        _podsticarijumContext.Remove(subCategorySpecificContent);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public Task<List<SubCategorySpecificContent>> GetAllSubCategorySpecific(bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategorySpecificContent
            .Include(sc => sc.SubCategory)
            .Include(sc => sc.SubCategory.Category);

        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(SubCategorySpecificContent content)
    {
        _podsticarijumContext.Add(content);
        var insertedId = await _podsticarijumContext.SaveChangesAsync();
        return insertedId;
    }

    public Task<SubCategorySpecificContent?> GetSubCategorySpecific(long id, bool tracking = false)
    {
        var query = _podsticarijumContext.SubCategorySpecificContent
            .Where(scc => scc.Id == id)
            .Include(scc => scc.SubCategory)
            .Include(scc => scc.SubCategory.Category);

        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }
}
