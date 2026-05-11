using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using System.Globalization;

namespace StoreFlow.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial:ViewComponent
    {
        private readonly MyContext _context;

        public _CardStatisticsDashboardComponentPartial(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
           var avg= _context.Customers.Average(x => x.Balance);
            var totalmoney =_context.Orders.Select(x => x.TotalPrice).Sum();

            ViewBag.CustomerTotalCount = _context.Customers.Count();
            ViewBag.CategoryTotalCount = _context.Categories.Count();
            ViewBag.CustomerBalanceAvg = avg.ToString("N2", new CultureInfo("tr-TR")) + "TL";
            ViewBag.TotalOrderCount = _context.Orders.Count();
            ViewBag.TotalProductCount = _context.Products.Count();
            ViewBag.TotalMoney = totalmoney.ToString("N2", new CultureInfo("tr-TR")) + "TL";
            return View();
        }
    }
}
