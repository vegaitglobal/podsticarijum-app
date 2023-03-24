using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository.Abstractions;

public interface ISubCategoryRepository
{
    Task<SubCategory?> Get(long id, bool tracking = false);

    Task<List<SubCategory>> GetAll(bool tracking = false);

    Task<List<SubCategory>> GetByNavMenuText(string navMenuText, bool tracking = false);

    Task<List<SubCategory>> GetForCategory(long categoryId, bool tracking = false);

    Task<List<SubCategorySpecificContent>> GetSubCategorySpecificForSubCategory(long subCategoryId, ParagraphSign paragraphSign = ParagraphSign.Default, bool tracking = false);

    Task<List<SubCategorySpecificContent>> GetAllSubCategorySpecific(bool tracking = false);

    Task<SubCategorySpecificContent?> GetSubCategorySpecific(long id, bool tracking = false);

    Task Update(SubCategory subCategory);

    Task Update(SubCategorySpecificContent content);

    Task Delete(SubCategory subCategory);

    Task Delete(SubCategorySpecificContent subCategorySpecificContent);

    Task<long> Insert(SubCategory subCategory);

    Task<long> Insert(SubCategorySpecificContent content);
}
