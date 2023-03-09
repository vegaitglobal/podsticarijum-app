using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

//[Authorize]
public class SubCategorySpecificCmsController : Controller
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    public SubCategorySpecificCmsController(ISubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }
    // GET: SubCategorySpecificController
    public async Task<ActionResult> Index()
    {
        List<SubCategorySpecificContent> contents = await _subCategoryRepository.GetAllSubCategorySpecific();

        return View(contents.ToDto());
    }

    // GET: SubCategorySpecificController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SubCategorySpecificController/Create
    public async Task<ActionResult> Create()
    {
        var subCategories = await _subCategoryRepository.GetAll();
        var paragraphSigns = Enum.GetValues<ParagraphSign>().Cast<ParagraphSign>();
        SubCategorySpecificViewModel contentViewModel = new()
        {
            SubCategoryDtoList = subCategories.Select(sc =>
                new SelectListItem()
                {
                    Text = sc.MainNavMenuText,
                    Value = sc.Id.ToString()
                }),
            ParagraphSigns = paragraphSigns.Select(ps =>
                new SelectListItem()
                {
                    Text = ps.ToString(),
                    Value = ((int)ps).ToString()
                }
            )
        };

        return View(contentViewModel);
    }

    // POST: SubCategorySpecificController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(SubCategorySpecificViewModel viewModel)
    {
        SubCategory? subCategory = await _subCategoryRepository
                                    .Get(viewModel.SubCategoryId, tracking: true)
                                    .ConfigureAwait(false);

        if (subCategory == null)
        {
            return NotFound();
        }

        ParagraphSign sign = ParagraphSign.Default;

        if (Enum.TryParse(viewModel.ParagraphSign, out sign))
        {
            SubCategorySpecificContent content = new(
                subCategory: subCategory,
                pageTitle: viewModel.PageTitle,
                paragraphText: viewModel.ParagraphText,
                paragraphSign: sign
                );

            await _subCategoryRepository.Insert(content);
        }

        return RedirectToAction("");
    }

    // GET: SubCategorySpecificController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        SubCategorySpecificContent? content = await _subCategoryRepository.GetSubCategorySpecific(id);
        List<SubCategory> subCategories = await _subCategoryRepository.GetAll();

        if (content == null)
        {
            return BadRequest();
        }

        var paragraphSigns = Enum.GetValues<ParagraphSign>().Cast<ParagraphSign>();
        
        SubCategorySpecificViewModel contentViewModel = new()
        {
            SubCategoryDtoList = subCategories.Select(sc =>
                new SelectListItem()
                {
                    Text = sc.MainNavMenuText,
                    Value = sc.Id.ToString(),
                    Selected = sc.Id == content.SubCategory.Id
                }),
            ParagraphSigns = paragraphSigns.Select(ps =>
                new SelectListItem()
                {
                    Text = ps.ToString(),
                    Value = ((int)ps).ToString(),
                    Selected = ps == content.ParagraphSign
                }
            ),
            ParagraphText = content.ParagraphText,
            PageTitle = content.PageTitle
        };

        return View(contentViewModel);
    }

    // POST: SubCategorySpecificController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, SubCategorySpecificViewModel viewModel)
    {
        ParagraphSign sign = ParagraphSign.Default;

        if (!Enum.TryParse(viewModel.ParagraphSign, out sign))
        {
            return BadRequest();
        }

        SubCategorySpecificContent? content = await _subCategoryRepository.GetSubCategorySpecific(id);
        if (content == null)
        {
            return BadRequest();
        }
        return Ok();

    }

    // GET: SubCategorySpecificController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: SubCategorySpecificController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
