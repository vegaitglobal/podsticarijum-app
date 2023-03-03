using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Api.Viewmodels;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
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
            List<Faq> faqs = await _faqRepository.GetAll();
            var subCategories = faqs.Select(f => f.SubCategory);

            return View(subCategories.ToDto());
        }

        // POST: FaqCmsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FaqViewModel faqViewModel)
        {
            SubCategory? subCategory = await _subCategoryRepository.Get(faqViewModel.SubCategoryId);

            if (subCategory == null)
            {
                return NotFound();
            }

            Faq faq = new(
                subCategory: subCategory,
                question: faqViewModel.Question,
                answer: faqViewModel.Answer);

            await _faqRepository.Insert(faq);

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

            return View();
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
}
