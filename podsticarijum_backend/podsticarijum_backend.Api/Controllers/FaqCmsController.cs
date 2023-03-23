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
public class FaqCmsController : Controller
{
    private readonly IFaqRepository _faqRepository;
    private readonly ISubCategoryRepository _subCategoryRepository;

    public FaqCmsController(
        IFaqRepository faqRepository, 
        ISubCategoryRepository subCategoryRepository)
    {
        _faqRepository = faqRepository;
        _subCategoryRepository = subCategoryRepository;
    }

    // GET: FaqCmsController
    public async Task<ActionResult<List<FaqDto>>> Index()
    {
        List<Faq> faqs = await _faqRepository.GetAll();
        return View(faqs.ToDto());
    }

    // GET: FaqCmsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: FaqCmsController/Create
    public async Task<ActionResult<List<SubCategoryDto>>> Create()
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetAll();
        subCategories = subCategories.DistinctBy(sc => sc.MainNavMenuText.Trim()).ToList();

        FaqViewModel faqViewModel = new()
        {
            SubCategoryDtoList = subCategories
                .Select(sc =>
                 new SelectListItem() 
                {
                    Text = sc.MainNavMenuText,
                    Value = sc.Id.ToString()
                }
            )
        };

        return View(faqViewModel);
    }

    // POST: FaqCmsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(FaqViewModel faqViewModel)
    {
        SubCategory? selectedSubCategory = await _subCategoryRepository.Get(faqViewModel.SubCategoryId, tracking: true);

        if (selectedSubCategory == null)
        {
            return NotFound();
        }

        List<SubCategory> subCategoriesByName = await _subCategoryRepository.GetByNavMenuText(selectedSubCategory.MainNavMenuText, tracking: true);

        IEnumerable<Faq> faqs = subCategoriesByName
            .Select(sc => new Faq(
            subCategory: sc,
            question: faqViewModel.Question,
            answer: faqViewModel.Answer));

        await _faqRepository.Insert(faqs);

        return RedirectToAction("");
    }

    // GET: FaqCmsController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        Faq? faq = await _faqRepository.Get(id, tracking: true);

        if (faq == null)
        {
            return NotFound();
        }
        
        return View(faq.ToDto());
    }

    // POST: FaqCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, FaqDto faqDto)
    {
        Faq? faq = await _faqRepository.Get(id, tracking: true);

        if (faq == null)
        {
            return NotFound();
        }

        faq.Question = faqDto.Question;
        faq.Answer = faqDto.Answer;
        faq.UpdatedAt = DateTime.UtcNow;
        await _faqRepository.Update(faq);

        return RedirectToAction("");
    }

    // GET: FaqCmsController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        Faq? faq = await _faqRepository.Get(id, tracking: true);

        if (faq == null)
        {
            return NotFound();
        }

        return View(faq.ToDto());
    }

    // POST: FaqCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        Faq? faq = await _faqRepository.Get(id, tracking: true);

        if (faq == null)
        {
            return NotFound();
        }

        await _faqRepository.Delete(faq);

        return RedirectToAction("");

    }
}
