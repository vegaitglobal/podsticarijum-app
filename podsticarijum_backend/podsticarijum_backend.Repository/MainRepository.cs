using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public async ValueTask<MainScreen?> Get(long Id) 
        => await _podsticarijumContext.MainScreen.FindAsync(Id)
                                                 .ConfigureAwait(false);

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
}
