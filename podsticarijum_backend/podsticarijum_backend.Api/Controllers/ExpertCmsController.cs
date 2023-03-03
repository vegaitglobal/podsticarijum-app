using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
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

        // GET: ExpertCmsController
        public async Task<ActionResult> Index()
        {
            List<Expert> experts = await _expertRepository.GetAll();

            return View(experts.ToDto());
        }

        // GET: ExpertCmsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpertCmsController/Create
        public async Task<ActionResult> Create()
        {
            List<SubCategory> subCategories = await _subCategoryRepository.GetAll();
            List<SelectListItem> selectListItems = subCategories
                .Select(sc => new SelectListItem()
                {
                    Text = $"{sc.MainNavMenuText} [{sc.Category.NavMenuText}]",
                    Value = sc.Id.ToString()
                })
                .ToList();

            ExpertViewModel expertViewModel = new()
            {
                SubCategoryList = selectListItems
            };

            return View(expertViewModel);
        }

        // POST: ExpertCmsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ExpertViewModel expertViewModel)
        {
            SubCategory? subCategory = await _subCategoryRepository.Get(expertViewModel.SubCategoryId);
            if (subCategory == null)
            {
                return NotFound();
            }

            Expert expert = new(
                subCategory: subCategory,
                firstName: expertViewModel.FirstName,
                lastName: expertViewModel.LastName,
                email: expertViewModel.Email,
                description: expertViewModel.Description);

            await _expertRepository.Insert(expert);

            return RedirectToAction("");
        }

        // GET: ExpertCmsController/Edit/5
        public async Task<ActionResult<ExpertDto>> Edit(int id)
        {
            Expert? expert = await _expertRepository.Get(id);
            if (expert == null)
            {
                return NotFound();
            }

            return View(expert.ToDto());
        }

        // POST: ExpertCmsController/Edit/5
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
            expert.LastName = expertDto.LastName;
            expert.Description = expertDto.Description;

            await _expertRepository.Update(expert);

            return RedirectToAction("");
        }

        // GET: ExpertCmsController/Delete/5
        public async Task<ActionResult<ExpertDto>> Delete(int id)
        {
            Expert? expert = await _expertRepository.Get(id);
            if (expert == null)
            {
                return NotFound();
            }

            return View(expert.ToDto());
        }

        // POST: ExpertCmsController/Delete/5
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
}
