using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

public class SubCategoryCmsController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;

    public SubCategoryCmsController(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
    {
        _categoryRepository = categoryRepository;
        _subCategoryRepository = subCategoryRepository;
    }

    // GET: SubCategoryCmsController
    public async Task<ActionResult> IndexAsync()
    {
        List<Category> categories = await _categoryRepository.GetAll();
        List<CategoryFullDto> categoryDtos = categories.ToFullDto();
        return View(categoryDtos);
    }

    // GET: SubCategoryCmsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SubCategoryCmsController/Create
    public async Task<ActionResult> Create()
    {
        List<Category> categories = await _categoryRepository.GetAll();
        List<CategoryDto> categoryDtos = categories.ToDto();

        SubCategoryViewModel subCategoryViewModel = new()
        {
            CategoryDtoList = categoryDtos.Select(c => new   SelectListItem()
                    {
                        Text = c.NavMenuText,
                        Value = c.Id.ToString(),
                    })
        };

        return View(subCategoryViewModel);
    }

    // POST: SubCategoryCmsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(SubCategoryViewModel subCategoryViewModel)
    {

        var selectedCategoryId = subCategoryViewModel.CategoryId;
        var category = await _categoryRepository.Get(selectedCategoryId, tracking: true);

        if (category == null)
        {
            return BadRequest();
        }

        subCategoryViewModel.SubCategoryDto.CategoryDto = category.ToDto();
        SubCategory subCategory = subCategoryViewModel.SubCategoryDto.ToDomainModel();
        subCategory.Category = category;

        _ = await _subCategoryRepository.Insert(subCategory);

        return RedirectToAction("");
    }

    // GET: SubCategoryCmsController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        SubCategory? subCategory = await _subCategoryRepository.Get(id);

        if (subCategory == null)
        {
            return NotFound();
        }

        SubCategoryViewModel subCategoryViewModel = new()
        {
            SubCategoryDto = subCategory.ToDto()
        };

        return View(subCategoryViewModel);
    }

    // POST: SubCategoryCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(
            int id,
            SubCategoryViewModel viewModel)
    {
        SubCategory? subCategory = await _subCategoryRepository
                                 .Get(id, tracking: true)
                                 .ConfigureAwait(false);

        if (subCategory == null)
        {
            return NotFound();
        }

        subCategory.UpdateFromDto(viewModel.SubCategoryDto);
        subCategory.UpdatedAt = DateTime.UtcNow;
        await _subCategoryRepository.Update(subCategory);

        return RedirectToAction("");
    }

    // GET: SubCategoryCmsController/Delete/5
    public async Task<ActionResult<SubCategoryDto>> Delete(int id)
    {
        SubCategory? subCategory = await _subCategoryRepository.Get(id);

        if (subCategory == null)
        {
            return NotFound();
        }

        return View(subCategory.ToDto());
    }

    // POST: SubCategoryCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        try
        {
            SubCategory? subCategory = await _subCategoryRepository.Get(id);

            if (subCategory == null)
            {
                return NotFound();
            }

            await _subCategoryRepository.Delete(subCategory);

            return RedirectToAction("");
        }
        catch
        {
            return View();
        }
    }
}
