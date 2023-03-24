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

    public Task<ExpertInfo?> GetExpertInfo(long expertId, bool tracking = false)
    {
        var query = _podsticarijumContext.ExpertInfo;
        return tracking ? query.FirstOrDefaultAsync() : query.AsNoTracking().FirstOrDefaultAsync();
    }

    public Task<List<Expert>> GetAll(bool tracking = false)
    {

        var query = _podsticarijumContext.Expert.Include(e => e.SubCategory)
                                                .Include(e => e.SubCategory.Category);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();

    }
    public Task<List<ExpertInfo>> GetAllExpertInfo(bool tracking = false)
    {
        var query = _podsticarijumContext.ExpertInfo;
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public Task<List<Expert>> GetExpertsForSubCategory(long subCategoryId, bool tracking = false)
    {
        var query = _podsticarijumContext.Expert.Include(e => e.SubCategory)
                                       .Include(e => e.SubCategory.Category)
                                       .Where(e => e.SubCategory.Id == subCategoryId);
        return tracking ? query.ToListAsync() : query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(Expert expert)
    {
        _podsticarijumContext.Add(expert);
        await _podsticarijumContext.SaveChangesAsync();
        return expert.Id;
    }

    public async Task<long> Insert(ExpertInfo expertInfo)
    {
        _podsticarijumContext.Add(expertInfo);
        await _podsticarijumContext.SaveChangesAsync();
        return expertInfo.Id;
    }

    public async Task Update(Expert expert)
    {
        _podsticarijumContext.Update(expert);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Update(ExpertInfo expertInfo)
    {
        _podsticarijumContext.Update(expertInfo);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Delete(Expert expert)
    {
        _podsticarijumContext.Remove(expert);
        await _podsticarijumContext.SaveChangesAsync();
    }
    public async Task Delete(ExpertInfo expertInfo)
    {
        _podsticarijumContext.Remove(expertInfo);
        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task InsertMany(IEnumerable<Expert> experts)
    {
        _podsticarijumContext.AddRange(experts);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
