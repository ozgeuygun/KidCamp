using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _AllActivitiesList : ViewComponent
    {
        EventDetailManager eventDetailManager = new EventDetailManager(new EfEventDetailDal());
        public IViewComponentResult Invoke()
        {
            var values = eventDetailManager.TGetList();
            return View(values);
        }
    }
}

