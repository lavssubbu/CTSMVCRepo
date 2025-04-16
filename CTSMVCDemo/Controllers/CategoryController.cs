using CTSMVCDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CTSMVCDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _catser;

        public CategoryController(ICategory catser)
        {
            _catser = catser;
        }

        public IActionResult Index()
        {
            return View(_catser.GetAllCategories());
        }
    }
}
