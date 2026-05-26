using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using System.Linq;

namespace StoreFlow.Controllers
{
    public class StatisticsController : Controller
    {
        // Veritabanı bağlantısı
        private readonly MyContext _myContext;

        public StatisticsController(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IActionResult Index()
        {
            // --- GENEL İSTATİSTİKLER ---

            // Toplam Ürün Sayısı
            ViewBag.TotalProductCount = _myContext.Products.Count();

            // Toplam Kategori Sayısı
            ViewBag.TotalCategoryCount = _myContext.Categories.Count();

            // Toplam Müşteri Sayısı
            ViewBag.TotalCustomerCount = _myContext.Customers.Count();

            // Toplam Sipariş Sayısı
            ViewBag.TotalOrderCount = _myContext.Orders.Count();


            // --- FİNANSAL İSTATİSTİKLER ---

            // Toplam Ciro (Siparişlerin Toplam Tutarı)
            var totalRevenue = _myContext.Orders.Sum(x => x.TotalPrice);
            ViewBag.TotalRevenue = totalRevenue.ToString("N2");

            // Toplam Gider
            var totalExpense = _myContext.Expenses.Sum(x => x.Amount);
            ViewBag.TotalExpense = totalExpense.ToString("N2");

            // Net Kar (Ciro - Gider)
            ViewBag.NetProfit = (totalRevenue - totalExpense).ToString("N2");


            // --- ÜRÜN VE STOK İSTATİSTİKLERİ ---

            // Kritik Stoktaki Ürün Sayısı (MinStockLevel'dan az olanlar)
            ViewBag.MinProductStockWarning = _myContext.Products.Where(x => x.ProductStock < x.MinStockLevel).Count();

            // En Pahalı Ürün
            var expensiveProduct = _myContext.Products.OrderByDescending(x => x.ProductPrice).FirstOrDefault();
            ViewBag.MostExpensiveProduct = expensiveProduct != null ? expensiveProduct.ProductName : "Yok";

            // En Ucuz Ürün
            var cheapestProduct = _myContext.Products.OrderBy(x => x.ProductPrice).FirstOrDefault();
            ViewBag.CheapestProduct = cheapestProduct != null ? cheapestProduct.ProductName : "Yok";


            // --- MÜŞTERİ İSTATİSTİKLERİ ---

            // En Çok Harcama Yapan Müşteri
            var biggestSpender = _myContext.Orders
                .Include(x => x.Customer)
                .GroupBy(x => new { x.Customer.FirstName, x.Customer.LastName })
                .Select(g => new
                {
                    CustomerName = g.Key.FirstName + " " + g.Key.LastName,
                    TotalSpent = g.Sum(s => s.TotalPrice)
                })
                .OrderByDescending(o => o.TotalSpent)
                .FirstOrDefault();

            if (biggestSpender != null)
            {
                ViewBag.BiggestCustomerName = biggestSpender.CustomerName;
                ViewBag.BiggestTotalSpent = biggestSpender.TotalSpent.ToString("N2");
            }
            else
            {
                ViewBag.BiggestCustomerName = "Veri Yok";
                ViewBag.BiggestTotalSpent = "0.00";
            }

            return View();
        }
    }
}
