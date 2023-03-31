using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Authorize]
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
                    Text = sc.MainNavMenuText + " " + sc.Category.NavMenuText,
                    Value = sc.Id.ToString()
                }),
            ParagraphSigns = paragraphSigns
            .Where(ps => ps != ParagraphSign.Default)
            .Select(ps =>
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

        bool enumParsed = Enum.TryParse(viewModel.ParagraphSign, out sign);
        
        if (!enumParsed || sign == ParagraphSign.Default)
        {
            return BadRequest();
        }

        SubCategorySpecificContent content = new(
            subCategory: subCategory,
            paragraphText: viewModel.ParagraphText,
            paragraphSign: sign
            );

        await _subCategoryRepository.Insert(content);


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
                    Text = sc.MainNavMenuText + " [" + sc.Category.NavMenuText + "]",
                    Value = sc.Id.ToString()
                }),
            ParagraphSigns = paragraphSigns
                .Where(ps => ps != ParagraphSign.Default)
                .Select(ps =>
                new SelectListItem()
                {
                    Text = ps.ToString(),
                    Value = ((int)ps).ToString()
                }
            ),
            ParagraphText = content.ParagraphText,
            ParagraphSign = ((int)content.ParagraphSign).ToString(),
            SubCategoryId = content.SubCategory.Id
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
        content.ParagraphSign = Enum.Parse<ParagraphSign>(viewModel.ParagraphSign);
        content.ParagraphText = viewModel.ParagraphText;
        if (content.SubCategory.Id != viewModel.SubCategoryId)
        {
            SubCategory? subCategory = await _subCategoryRepository.Get(viewModel.SubCategoryId, tracking: true);
            if (subCategory != null)
            {
                content.SubCategory = subCategory;
            }
        }

        await _subCategoryRepository.Update(content);

        return RedirectToAction("");
    }

    // GET: SubCategorySpecificController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        SubCategorySpecificContent? content = await _subCategoryRepository.GetSubCategorySpecific(id);

        if (content == null)
        {
            return NotFound();
        }


        return View(content.ToDto());
    }

    // POST: SubCategorySpecificController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection formCollection)
    {
        SubCategorySpecificContent? content = await _subCategoryRepository.GetSubCategorySpecific(id);

        if (content == null)
        {
            return NotFound();
        }

        await _subCategoryRepository.Delete(content);
        return RedirectToAction("");
    }
}
