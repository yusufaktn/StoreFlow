using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _SocialStatsDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
