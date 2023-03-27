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
public class MainCmsController : Controller
{
    private readonly IMainRepository _mainRepository;

    public MainCmsController(IMainRepository mainRepository)
    {
        _mainRepository = mainRepository;
    }

    // GET: MainCmsController
    public async Task<ActionResult> Index()
    {
        List<Content>? content = await _mainRepository.GetAll();

        if (content == null)
        {
            return NotFound();
        }

        return View(content.ToDto());
    }

    // GET: MainCmsController/Create
    public ActionResult Create()
    {
        var contentTypes = Enum.GetValues(typeof(ContentType)).Cast<ContentType>();
        IEnumerable<SelectListItem> contentTypeSelectList = contentTypes.Select(ct => new SelectListItem()
        {
            Text = ct.ToString(),
            Value = ((int)ct).ToString()
        });

        ContentViewModel content = new()
        {
            ContentTypeList = contentTypeSelectList
        };

        return View(content);
    }

    // POST: MainCmsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ContentViewModel contentViewModel)
    {
        var contents = await _mainRepository.GetAll();
        var contentTypes = Enum.GetValues(typeof(ContentType)).Cast<ContentType>();
        if (!containsOneEach(contents, contentTypes))
            
        {
            return BadRequest();
        }

        var content = new Content(
            contentType: contentViewModel.ContentType,
            text: contentViewModel.Content,
            additionalText: contentViewModel.AdditionalContent);

        await _mainRepository.Insert(content);

        return RedirectToAction("");
    }

    private bool containsOneEach(
        IEnumerable<Content> contents,
        IEnumerable<ContentType> contentTypes)
    {
        var groupings = contents
            .Where(c => contentTypes.Contains(c.ContentType))
            .GroupBy(c => c.ContentType);

        foreach(var grouping in groupings)
        {
            if (grouping.Count() > 1)
            {
                return false;
            }
        }
        return true;
    }


    // GET: MainCmsController/Edit/5
    public async Task<ActionResult<ContentDto>> Edit(int id)
    {
        Content? content = await _mainRepository.GetContentById(id);
        if (content == null)
        {
            return NotFound();
        }

        return View(content.ToDto());
    }

    // POST: MainCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, ContentDto contentDto)
    {
        Content? content = await _mainRepository.GetContentById(id);
        if (content == null)
        {
            return NotFound();
        }
        if (string.IsNullOrEmpty(contentDto.Text))
        {
            return BadRequest();
        }

        content.Text = contentDto.Text;
        content.AdditionalText = contentDto.AdditionalText;
        content.UpdatedAt = DateTime.UtcNow;
        await _mainRepository.Update(content);

        return RedirectToAction("");
    }

    // GET: MainCmsController/Delete/5
    public async Task<ActionResult<ContentDto>> Delete(int id)
    {
        Content? content = await _mainRepository.GetContentById(id);
        if(content == null)
        {
            return NotFound();
        }

        return View(content.ToDto());
    }

    // POST: MainCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, ContentDto contentDto)
    {
        Content? content = await _mainRepository.GetContentById(id);
        if (content == null)
        {
            return NotFound();
        }

        await _mainRepository.Delete(content);

        return RedirectToAction("");
    }
}
