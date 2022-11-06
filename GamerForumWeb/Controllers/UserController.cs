using Microsoft.AspNetCore.Mvc;

namespace GamerForumWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
