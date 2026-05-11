using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MyContext _myContext;

        public StatisticsController(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IActionResult Index()
        {
            var value= _myContext.Expenses.Select(x => x.Amount).Sum(); //Toplam gider
            ViewBag.TotalExpens = value.ToString("N2");

            ViewBag.MinProductStockWarning = _myContext.Products.Where(x => x.ProductStock < x.MinStockLevel).Count(); // Stok seviyesi minimum olan ürünleri getirme
            ViewBag.TotalSupplier = _myContext.Suppliers.Count(); //Tedarikçi sayısı

            var biggestSpender = _myContext.Orders // En çok harcama yapan müşteri adı.
                .GroupBy(x => x.Customer)
                .Select(x => new
                {
                    CustomerName = x.Key.FirstName+" "+x.Key.LastName,
                    TotalSpent = x.Sum(x => x.TotalPrice)
                })
                .OrderByDescending(x => x.TotalSpent)
                .FirstOrDefault();
            ViewBag.BiggeestCustomerName = biggestSpender.CustomerName;
            ViewBag.BiggestTotalSpent = biggestSpender.TotalSpent;


            return View();
        }
    }
}
