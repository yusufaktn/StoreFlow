using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _TodosDashboardComponentPartial : ViewComponent
    {
        private readonly MyContext _context;

        public _TodosDashboardComponentPartial(MyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var todos = _context.TodoItems.OrderBy(x => x.IsCompleted).ToList();
            return View(todos);
        }
    }
}
