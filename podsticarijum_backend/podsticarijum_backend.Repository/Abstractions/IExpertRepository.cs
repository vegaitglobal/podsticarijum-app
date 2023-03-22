using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface IExpertRepository
{
    Task<Expert?> Get(long expertId, bool tracking = false);

    Task<ExpertInfo?> GetExpertInfo(long expertInfoId, bool tracking = false);

    Task<List<Expert>> GetExpertsForSubCategory(long subCategoryId, bool tracking = false);

    Task<List<Expert>> GetAll(bool tracking = false);

    Task<List<ExpertInfo>> GetAllExpertInfo(bool tracking = false);

    Task<long> Insert(Expert expert);

    Task<long> Insert(ExpertInfo expertInfo);

    Task InsertMany(IEnumerable<Expert> experts);

    Task Update(Expert expert);

    Task Update(ExpertInfo expertInfo);

    Task Delete(Expert expert);

    Task Delete(ExpertInfo experoInfot);
}
