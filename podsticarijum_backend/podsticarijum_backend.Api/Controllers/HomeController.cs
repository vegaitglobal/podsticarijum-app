using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace podsticarijum_backend.Api.Controllers;

[Authorize]
public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
