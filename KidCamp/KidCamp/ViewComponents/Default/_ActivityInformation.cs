using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _ActivityInformation : ViewComponent
    {
        private readonly IActivityInformationService _activityInformationService;

        public _ActivityInformation(IActivityInformationService activityInformationService)
        {
            _activityInformationService = activityInformationService;
        }

        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
