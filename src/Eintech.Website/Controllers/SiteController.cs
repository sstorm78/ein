using Microsoft.AspNetCore.Mvc;

namespace Eintech.Website.Controllers
{
    public class SiteController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}