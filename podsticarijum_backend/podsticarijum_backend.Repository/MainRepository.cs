using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Repository;

public class MainRepository : IMainRepository
{
    private readonly PodsticarijumContext _podsticarijumContext;

    public MainRepository(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext;
    }

    public async ValueTask<MainScreen?> Get(long id, bool tracking = false)
    {
        var query = _podsticarijumContext.MainScreen.Where(ms => ms.Id == id);
        return tracking ? await query.FirstOrDefaultAsync() : await query.AsNoTracking().FirstOrDefaultAsync();
    }
                                                 
    public async ValueTask<List<MainScreen>> GetActive(bool tracking = false)
    {
        var query = _podsticarijumContext.MainScreen.Where(ms => ms.Active == true);
        return tracking ? await query.ToListAsync() : await query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(MainScreen mainScreen)
    {
        await _podsticarijumContext.AddAsync(mainScreen);
        await _podsticarijumContext.SaveChangesAsync();
        return mainScreen.Id;
    }

    public async Task Update(MainScreen mainScreen)
    {
        _podsticarijumContext.Update(mainScreen);

        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Update(IEnumerable<MainScreen> mainScreens)
    {
        _podsticarijumContext.UpdateRange(mainScreens);

        await _podsticarijumContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task Delete(MainScreen mainScreen)
    {
        _podsticarijumContext.Remove(mainScreen);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
