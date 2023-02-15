using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IMainRepository
{

    Task<Content?> GetContentById(long id, bool tracking = false);

    Task<List<Content>> GetContentByType(ContentType contentType, bool tracking = false);

    Task Delete(Content contents);

    Task Update(Content contents);

    Task Update(IEnumerable<Content> contents);

    Task<long> Insert(Content contents);
}
