using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Authorize]
public class ExpertInfoCmsController : Controller
{
    private readonly IExpertRepository _expertRepository;

    public ExpertInfoCmsController(IExpertRepository expertRepository)
    {
        _expertRepository = expertRepository;
    }

    // GET: ExpertInfoCmsController
    public async Task<ActionResult> Index()
    {
        List<ExpertInfo> expertInfos = await _expertRepository.GetAllExpertInfo();

        return View(expertInfos.ToDto());
    }

    // GET: ExpertInfoCmsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ExpertInfoCmsController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ExpertInfoCmsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ExpertInfoRequestDto expertInfoRequestDto)
    {
        
        await _expertRepository.Insert(expertInfoRequestDto.ToDomainModel());

        return RedirectToAction("");
    }

    // GET: ExpertInfoCmsController/Edit/5
    public async Task<ActionResult<ExpertInfoDto>> Edit(int id)
    {
        ExpertInfo? expert = await _expertRepository.GetExpertInfo(id);
        if (expert == null)
        {
            return NotFound();
        }

        return View(expert.ToDto());
    }

    // POST: ExpertInfoCmsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, ExpertInfoRequestDto expertDto)
    {
        ExpertInfo? expertInfo = await _expertRepository.GetExpertInfo(id, tracking: true);
        if (expertInfo == null)
        {
            return NotFound();
        }

        expertInfo.Title = expertDto.Title;
        expertInfo.Content = expertDto.Content;

        await _expertRepository.Update(expertInfo);

        return RedirectToAction("");
    }

    // GET: ExpertInfoCmsController/Delete/5
    public async Task<ActionResult<ExpertInfoDto>> Delete(int id)
    {
        ExpertInfo? expertInfo = await _expertRepository.GetExpertInfo(id);
        if (expertInfo == null)
        {
            return NotFound();
        }

        return View(expertInfo.ToDto());
    }

    // POST: ExpertInfoCmsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        ExpertInfo? expertInfo = await _expertRepository.GetExpertInfo(id);
        if (expertInfo == null)
        {
            return NotFound();
        }
        await _expertRepository.Delete(expertInfo);

        return RedirectToAction("");
    }
}
