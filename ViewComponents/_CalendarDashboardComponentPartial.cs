using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _CalendarDashboardComponentPartial : ViewComponent
    {
        private readonly MyContext _mycontext;

        public _CalendarDashboardComponentPartial(MyContext mycontext)
        {
            _mycontext = mycontext;
        }

        public IViewComponentResult Invoke()
        {
            var last5product = _mycontext.Products.OrderByDescending(x=>x.CreatedDate).Take(5).ToList();
            return View(last5product);
        }
    }
}
