using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface ICategoryRepository
{


    Task<Category?> Get(long Id);

    Task<List<Category>> GetActive();

    Task Update(Category category);

    Task<long> Insert(Category category);
}
