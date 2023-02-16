using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
    public class SubCategoryCmsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public SubCategoryCmsController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubCategoryCmsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoryCmsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubCategoryCmsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoryCmsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategoryCmsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
