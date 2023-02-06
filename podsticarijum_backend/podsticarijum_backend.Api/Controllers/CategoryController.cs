using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IFaqRepository _faqRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;

    public CategoryController(
        IFaqRepository faqRepository,
        ICategoryRepository categoryRepository,
        ISubCategoryRepository subCategoryRepository)
    {
        _faqRepository = faqRepository;
        _categoryRepository = categoryRepository;
        _subCategoryRepository = subCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllActive()
    {
        try
        {
            List<Category> categories = await _categoryRepository.GetActive();

            return Ok(categories.ToDto());
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> Get([FromRoute] long id)
    {
        try
        {
            Category? category = await _categoryRepository.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            CategoryDto categoryDto = category.ToDto();
            return Ok(categoryDto);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{categoryId}/sub-category/")]
    public async Task<ActionResult<SubCategoryDto>> GetSubCategoriesForCategory([FromRoute] long categoryId)
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetActiveForCategory(categoryId).ConfigureAwait(false);

        if (subCategories.Count() == 0)
        {
            return NotFound();
        }

        return Ok(subCategories.ToDto());
    }

    [HttpPost("{categoryId}/sub-category/")]
    public async Task<ActionResult> PostSubCategory([FromRoute] long categoryId, [FromBody] SubCategoryDto subCategoryDto)
    {
        if (subCategoryDto == null || subCategoryDto.MainText == null)
        {
            return BadRequest();
        }
        var category = await _categoryRepository.Get(categoryId);
        if (category == null)
        {
            return BadRequest();
        }
        subCategoryDto.CategoryDto = category.ToDto();
        SubCategory subCategory = subCategoryDto.ToDomainModel();
        await _subCategoryRepository.Insert(subCategory);

        subCategory.Category.Id = categoryId;


        return Ok(subCategory);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto categoryDto)
    {
        try
        {
            if (categoryDto == null || categoryDto.NavMenuText == null)
            {
                return BadRequest();
            }
            Category entity = categoryDto.ToDomainModel();
            categoryDto.Id = await _categoryRepository.Insert(entity);

            return Ok(categoryDto);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] long id, [FromBody] CategoryDto categoryDto)
    {
        if (isCategoryDtoValid(categoryDto))
        {
            return BadRequest();
        }

        Category? category = await _categoryRepository.Get(id).ConfigureAwait(false);
        if (category == null)
        {
            return BadRequest();
        }
        try
        {
            await _categoryRepository.Update(categoryDto.ToDomainModel());
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{categoryId}/faq")]
    public async Task<ActionResult<List<Faq>>> GetAllForCategory([FromRoute] long categoryId)
    {
        List<Faq> faqs = await _faqRepository.GetFaqsForCategory(categoryId).ConfigureAwait(false);

        return Ok(faqs);
    }

    [HttpPost("{categoryId}/faq")]
    public async Task<ActionResult<Faq>> CreateFaq([FromRoute] long categoryId, [FromBody] FaqDto faqDto)
    {
        if ( string.IsNullOrEmpty(faqDto.Question) || string.IsNullOrEmpty(faqDto.Answer))
        {
            return BadRequest("FAQ should have non empty question and answer.");
        }
        Category? category = await _categoryRepository.Get(categoryId).ConfigureAwait(false);
        if(category == null)
        {
            return BadRequest("Category does not exist.");
        }
        faqDto.CategoryDto = category.ToDto();

        _ = await _faqRepository.Insert(faqDto.ToDomainModel());
        return Ok(faqDto);
    }

    [HttpDelete("{categoryId}")]
    public async Task<ActionResult> Delete([FromRoute] long categoryId)
    {
        Category? category = await _categoryRepository.Get(categoryId).ConfigureAwait(false);
        if (category == null)
        {
            return NotFound();
        }
        await _categoryRepository.Delete(category);

        return NoContent();
    }

    private static bool isCategoryDtoValid(CategoryDto categoryDto)
        => categoryDto == null || categoryDto.Id != 0 || categoryDto.NavMenuText == null;
}
