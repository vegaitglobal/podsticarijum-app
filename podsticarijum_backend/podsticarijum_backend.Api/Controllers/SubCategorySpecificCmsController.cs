using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace podsticarijum_backend.Api.Controllers;

//[Authorize]
public class SubCategorySpecificCmsController : Controller
{
    // GET: SubCategorySpecificController
    public ActionResult Index()
    {
        return View();
    }

    // GET: SubCategorySpecificController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: SubCategorySpecificController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: SubCategorySpecificController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: SubCategorySpecificController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: SubCategorySpecificController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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
