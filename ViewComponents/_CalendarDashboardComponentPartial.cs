using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _CalendarDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
