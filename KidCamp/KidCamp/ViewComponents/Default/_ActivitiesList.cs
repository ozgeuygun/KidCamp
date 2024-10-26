using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _ActivitiesList : ViewComponent
    {
        EventDetailManager eventDetailManager = new EventDetailManager(new EfEventDetailDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = eventDetailManager.TGetGenreById(id);
            return View(values);
        }
    }
}
