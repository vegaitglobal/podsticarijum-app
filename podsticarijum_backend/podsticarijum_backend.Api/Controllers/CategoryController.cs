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
            List<Category> categories = await _categoryRepository.GetAll();
            List<CategoryDto> categoryDtos = categories.ToDto();
            return Ok(categoryDtos);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Get a single category by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Categorys object.</returns>
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

    /// <summary>
    /// Get a list of subcategories for this category.
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpGet("{categoryId}/sub-category/")]
    public async Task<ActionResult<List<SubCategoryDto>>> GetSubCategoriesForCategory([FromRoute] long categoryId)
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetForCategory(categoryId).ConfigureAwait(false);

        return Ok(subCategories.ToDto());
    }

    [HttpPost("{categoryId}/sub-category/")]
    public async Task<ActionResult> PostSubCategory([FromRoute] long categoryId, [FromBody] SubCategoryRequestDto subCategoryDto)
    {
        if (subCategoryDto == null || subCategoryDto.MainText == null)
        {
            return BadRequest();
        }

        var category = await _categoryRepository.Get(categoryId, tracking: true);

        if (category == null)
        {
            return BadRequest();
        }

        subCategoryDto.CategoryDto = category.ToDto();
        SubCategory subCategory = subCategoryDto.ToDomainModel();
        subCategory.Category = category;
        await _subCategoryRepository.Insert(subCategory);

        subCategory.Category.Id = categoryId;

        return Ok(subCategory);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryRequestDto categoryDto)
    {
        try
        {
            if (categoryDto == null || categoryDto.NavMenuText == null)
            {
                return BadRequest();
            }
            Category entity = categoryDto.ToDomainModel();
            CategoryDto categoryOutputDto = entity.ToDto();
            categoryOutputDto.Id = await _categoryRepository.Insert(entity);

            return Ok(categoryOutputDto);
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
    public async Task<ActionResult<Faq>> CreateFaq([FromRoute] long categoryId, [FromBody] FaqRequestDto faqRequestDto)
    {
        if (string.IsNullOrEmpty(faqRequestDto.Question) || string.IsNullOrEmpty(faqRequestDto.Answer))
        {
            return BadRequest("FAQ should have non empty question and answer.");
        }
        Category? category = await _categoryRepository.Get(categoryId, tracking: true).ConfigureAwait(false);
        if (category == null)
        {
            return BadRequest("Category does not exist.");
        }

        var faqDto = new FaqDto(question: faqRequestDto.Question, answer: faqRequestDto.Answer);
        faqDto.CategoryDto = category.ToDto();
        var faq = faqDto.ToDomainModel();
        faq.Category = category;

        var insertedFaqId = await _faqRepository.Insert(faq);
        faqDto.Id = insertedFaqId;

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

    private static bool isCategoryDtoValid(CategoryRequestDto categoryDto)
        => categoryDto == null || categoryDto.NavMenuText == null;
}
