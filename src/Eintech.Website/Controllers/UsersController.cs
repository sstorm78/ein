using Microsoft.AspNetCore.Mvc;

namespace Eintech.Website.Controllers
{
    public class UsersController : Controller
    {
        [Route("users")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("users/add")]
        public IActionResult Add()
        {
            return View();
        }
    }
}