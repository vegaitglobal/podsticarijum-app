using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Authorize]
public class ExpertCmsController : Controller
{
    private readonly IExpertRepository _expertRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;

    public ExpertCmsController(
        IExpertRepository expertRepository,
        ISubCategoryRepository subCategoryRepository
        )
    {
        _expertRepository = expertRepository;
        _subCategoryRepository = subCategoryRepository;
    }

    // GET: ExpertInfoCmsController
    public async Task<ActionResult> Index()
    {
        List<Expert> experts = await _expertRepository.GetAll();

        return View(experts.ToDto());
    }

    // GET: ExpertInfoCmsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ExpertInfoCmsController/Create
    public async Task<ActionResult> Create()
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetAll();
        subCategories = subCategories.DistinctBy(sc => sc.MainNavMenuText.Trim()).ToList();

        var selectListItems = subCategories.Select(sc => new SelectListItem()
        {
            Text = sc.MainNavMenuText,
            Value = sc.Id.ToString()
        });

        ExpertViewModel expertViewModel = new()
        {
            SubCategoryList = selectListItems
        };

        return View(expertViewModel);
    }

    // POST: ExpertInfoCmsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ExpertViewModel expertViewModel)
    {
        SubCategory? selectedSubCategory = await _subCategoryRepository.Get(expertViewModel.SubCategoryId);
        if (selectedSubCategory == null)
        {
            return NotFound();
        }
        
        List<Expert> expertBySubCategory = await _expertRepository.GetExpertsForSubCategory(selectedSubCategory.Id);

        if (expertBySubCategory.Any())
        {
            return BadRequest();
        }

        List<SubCategory> subCategoriesByName = await _subCategoryRepository.GetByNavMenuText(selectedSubCategory.MainNavMenuText, tracking: true);

        IEnumerable<Expert> experts = subCategoriesByName
            .Select(sc =>
                new Expert(
                subCategory: sc,
                firstName: expertViewModel.FirstName,
                lastName: expertViewModel.LastName,
                email: expertViewModel.Email,
                description: expertViewModel.Description)
        );

        await _expertRepository.InsertMany(experts);

        return RedirectToAction("");
    }

    // GET: ExpertInfoCmsController/Edit/5
    public async Task<ActionResult<ExpertDto>> Edit(int id)
    {
        Expert? expert = await _expertRepository.Get(id);
        if (expert == null)
        {
            return NotFound();
        }

        return View(expert.ToDto());
    }

    // POST: ExpertInfoCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, ExpertDto expertDto)
    {
        Expert? expert = await _expertRepository.Get(id, tracking: true);
        if (expert == null)
        {
            return NotFound();
        }

        expert.Email = expertDto.Email;
        expert.FirstName = expertDto.FirstName;
        expert.LastName = expertDto.LastName ?? string.Empty;
        expert.Description = expertDto.Description;

        await _expertRepository.Update(expert);

        return RedirectToAction("");
    }

    // GET: ExpertInfoCmsController/Delete/5
    public async Task<ActionResult<ExpertDto>> Delete(int id)
    {
        Expert? expert = await _expertRepository.Get(id);
        if (expert == null)
        {
            return NotFound();
        }

        return View(expert.ToDto());
    }

    // POST: ExpertInfoCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        Expert? expert = await _expertRepository.Get(id);
        if (expert == null)
        {
            return NotFound();
        }
        await _expertRepository.Delete(expert);

        return RedirectToAction("");
    }
}
