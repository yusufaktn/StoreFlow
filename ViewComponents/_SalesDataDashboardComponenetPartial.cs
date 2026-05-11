using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _SalesDataDashboardComponenetPartial : ViewComponent
    {
        private readonly MyContext _context;

        public _SalesDataDashboardComponenetPartial(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Orders.OrderByDescending(o => o.OrderId)
                .Include(x => x.OrderDetails)
                .ThenInclude(y => y.Product)
                .Include(x => x.Customer).Take(5).ToList();


            return View(value);
        }
    }
}
