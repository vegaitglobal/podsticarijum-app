using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

//[Authorize]
public class CategoryCmsController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCmsController(
        ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // GET: CategoryCmsController
    public async Task<ActionResult> IndexAsync()
    {
        List<Category> categories = await _categoryRepository.GetAll();
        List<CategoryDto> categoryDtos = categories.ToDto();
        return View(categoryDtos);
    }

    // GET: CategoryCmsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    //[Authorize(CookieAuthenticationDefaults.AuthenticationScheme)]
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    // GET: CategoryCmsController/Create
    public async Task<ActionResult> Create(CategoryRequestDto categoryDto)
    {
        if (categoryDto == null || categoryDto.NavMenuText == null)
        {
            return BadRequest();
        }
        Category entity = categoryDto.ToDomainModel();
        CategoryDto categoryOutputDto = entity.ToDto();
        categoryOutputDto.Id = await _categoryRepository.Insert(entity);

        return RedirectToAction(nameof(Index));
    }

    // GET: CategoryCmsController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var category = await _categoryRepository.Get(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category.ToDto());
    }

    // POST: CategoryCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CategoryRequestDto categoryRequestDto)
    {
        try
        {
            Category? category = await _categoryRepository.Get(id, tracking: true).ConfigureAwait(false);
            
            if (category == null)
            {
                return View();
            }
            category.NavMenuText = categoryRequestDto.NavMenuText;
            category.Description = categoryRequestDto.Description;
            category.UpdatedAt = DateTime.UtcNow;
            await _categoryRepository.Update(category);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CategoryCmsController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        Category? category = await _categoryRepository.Get(id);
        if (category == null)
        {
            return NotFound();
        }

        CategoryDto categoryDto = category.ToDto();
        return View(categoryDto);
    }

    // POST: CategoryCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        try
        {
            Category? category = await _categoryRepository.Get(id).ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.Delete(category);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
