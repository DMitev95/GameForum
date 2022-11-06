using Microsoft.AspNetCore.Mvc;

namespace GamerForumWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
