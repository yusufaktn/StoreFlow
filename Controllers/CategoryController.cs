using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entity;

namespace StoreFlow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyContext _context;

        public CategoryController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorylist = _context.Categories.ToList();
            return View(categorylist);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
