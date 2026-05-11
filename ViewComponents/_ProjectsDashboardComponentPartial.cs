using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _ProjectsDashboardComponentPartial : ViewComponent
    {
        private readonly MyContext _context;

        public _ProjectsDashboardComponentPartial(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects.Take(5).ToList();
            return View(projects);
        }
    }
}
