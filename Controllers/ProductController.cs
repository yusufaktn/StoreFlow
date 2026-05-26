using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreFlow.Context;
using StoreFlow.Entity;

namespace StoreFlow.Controllers
{
    public class ProductController : Controller
    {
        private MyContext _myContext;

        public ProductController(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IActionResult Index(int page=1 , int pagesize=10,string? searchtext =null)
        {
            var query = _myContext.Products.OrderBy(x => x.ProductId).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchtext))
            {
                query = query.Where(x=>x.ProductName.Contains(searchtext));// Burada aslında StartsWith kullanımı da olabilir.
            }
            var totalCount = query.Count();
            var product = query.Skip((page-1)*pagesize).Take(pagesize).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pagesize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pagesize);
            ViewBag.SearchText = searchtext;

            return View(product);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            List<SelectListItem> category = _myContext.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();
            ViewBag.CategoryList = category;
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _myContext.Products.Add(product);
            _myContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _myContext.Products.Find(id);
            _myContext.Products.Remove(product);
            _myContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var products = _myContext.Products.Find(id);
            return View(products);

        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var value = _myContext.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.ProductStock = product.ProductStock;
            value.ProductPrice = product.ProductPrice;
            value.Status = product.Status;
            _myContext.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
