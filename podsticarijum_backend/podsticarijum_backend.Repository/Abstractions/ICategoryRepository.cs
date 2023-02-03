using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface ICategoryRepository
{
    Task<Category?> Get(long id, bool tracking = false);

    Task<List<Category>> GetActive(bool tracking = false);

    Task Update(Category category);

    Task Delete(Category category);

    Task<long> Insert(Category category);
}
