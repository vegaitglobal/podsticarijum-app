using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface ISubCategoryRepository
{
    Task<SubCategory?> Get(long id, bool tracking = false);

    Task<List<SubCategory>> GetAll(bool tracking = false);

    Task<List<SubCategory>> GetForCategory(long categoryId, bool tracking = false);

    Task<List<SubCategorySpecificContent>> GetSubCategorySpecific(long subCategoryId, ParagraphSign paragraphSign = ParagraphSign.Default, bool tracking = false);

    Task Update(SubCategory subCategory);

    Task Delete(SubCategory subCategory);

    Task<long> Insert(SubCategory subCategory);
}
