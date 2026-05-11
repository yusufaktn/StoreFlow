using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _InboxDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
