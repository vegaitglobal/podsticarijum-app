using Microsoft.AspNetCore.Mvc;

namespace podsticarijum_backend.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
