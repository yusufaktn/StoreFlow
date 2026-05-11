using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _NavbarDashboardComponenetPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
