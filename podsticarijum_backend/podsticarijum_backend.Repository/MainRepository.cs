using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using podsticarijum_backend.Domain;
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

    public Task<User?> GetUser(string username, string password)
        => _podsticarijumContext.User.Where(
            u => username.ToLower() == u.Username.ToLower()
            && password.ToLower() == u.Password.ToLower()
            ).FirstOrDefaultAsync();
    

    public async Task<Content?> GetContentById(long id, bool tracking = false)
    {
        var query = _podsticarijumContext.Content.Where(c => c.Id == id);
        return tracking ? await query.FirstOrDefaultAsync() : await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<List<Content>> GetContentByType(ContentType contentType, bool tracking = false)
    {
        var query = _podsticarijumContext.Content.Where(c => c.ContentType == contentType);
        return tracking ? await query.ToListAsync() : await query.AsNoTracking().ToListAsync();
    }

    public async Task<List<Content>> GetAll(bool tracking = false)
    {
        var query = _podsticarijumContext.Content;
        return tracking ? await query.ToListAsync() : await query.AsNoTracking().ToListAsync();
    }

    public async Task<long> Insert(Content content)
    {
        await _podsticarijumContext.AddAsync(content);
        await _podsticarijumContext.SaveChangesAsync();
        return content.Id;
    }

    public async Task Update(Content content)
    {
        _podsticarijumContext.Update(content);

        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task Update(IEnumerable<Content> contents)
    {
        _podsticarijumContext.UpdateRange(contents);

        await _podsticarijumContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task Delete(Content content)
    {
        _podsticarijumContext.Remove(content);
        await _podsticarijumContext.SaveChangesAsync();
    }
}
