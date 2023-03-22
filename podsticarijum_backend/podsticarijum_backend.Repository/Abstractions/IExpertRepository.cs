using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IExpertRepository
{
    Task<Expert?> Get(long expertId, bool tracking = false);

    Task<List<Expert>> GetExpertsForSubCategory(long subCategoryId, bool tracking = false);

    Task<List<Expert>> GetAll(bool tracking = false);

    Task<long> Insert(Expert expert);

    Task InsertMany(IEnumerable<Expert> experts);

    Task Update(Expert expert);

    Task Delete(Expert expert);
}
