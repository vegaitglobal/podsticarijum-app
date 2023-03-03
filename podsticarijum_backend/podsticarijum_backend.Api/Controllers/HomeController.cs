using Microsoft.AspNetCore.Mvc;

namespace podsticarijum_backend.Api.Controllers;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
