using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Instructor.Controllers
{ 
    [Area("Instructor")]
    [Authorize(Roles = "Admin,Instructor")]
    public class ActivitiesController : Controller
    {
        private readonly IEventDetailService _eventDetailService;

        public ActivitiesController(IEventDetailService eventDetailService)
        {
            _eventDetailService = eventDetailService;
        }

        public IActionResult Index()
        {
            var activityList = _eventDetailService.TGetList();
            return View(activityList);
        }
        public IActionResult ActivityDetails(int id)
        {
            var detailsList = _eventDetailService.TGetByID(id);
            return View(detailsList);
        }
    }
}
