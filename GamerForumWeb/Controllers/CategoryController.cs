using GamerForumWeb.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GamerForumWeb.Controllers
{    
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<IActionResult> AllCategories()
        {
            var model = await categoryService.GetAllCategory();

            return View(model);
        }
    }
}
