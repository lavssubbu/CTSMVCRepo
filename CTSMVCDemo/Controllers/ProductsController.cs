using CTSMVCDemo.Models;
using CTSMVCDemo.Repository;
using CTSMVCDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTSMVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _service;
        private readonly ICategory _catser;

        public ProductsController(IProduct service, ICategory catser)
        {
            _service = service;
            _catser = catser;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllProducts());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_catser.GetAllCategories(), "catId", "catName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
                ViewBag.Categories = new SelectList(_catser.GetAllCategories(), "catId", "catName");

                _service.AddProduct(product);
                return RedirectToAction("Index");
           
        }

        public IActionResult Edit(int id)
        {
            var product = _service.GetProductById(id);
            ViewBag.Categories = new SelectList(_catser.GetAllCategories(), "catId", "catName", product.categoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ViewBag.Categories = new SelectList(_catser.GetAllCategories(), "catId", "catName", product.categoryId);
            _service.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_service.GetProductById(id));
        }

        public IActionResult Delete(int id)
        {
            return View(_service.GetProductById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
