using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _ActivitiesChartDashboardComponentPartial:ViewComponent
    {
        private readonly MyContext _myContext;

        public _ActivitiesChartDashboardComponentPartial(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IViewComponentResult Invoke()
        {
            var activities = _myContext.Activities.Take(4).ToList();// 4 tane aktivite al 

            return View(activities);// View'a dön.
        }
    }
}
