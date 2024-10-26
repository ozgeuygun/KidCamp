using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;


namespace KidCamp.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
    public class ActivitiesController : Controller
    {
        
        private readonly IEventDetailService _eventDetailService;

        public ActivitiesController(IEventDetailService eventDetailService)
        {
            _eventDetailService = eventDetailService;
        }

        public IActionResult ListCamps()
        {
            var campList = _eventDetailService.GetCamp();
           

            return View(campList);
        }
       
        public IActionResult ListEvents()
        {

			var eventList = _eventDetailService.GetEvent();

            return View(eventList);
        }
    
        public IActionResult Index(string searchTerm,int page=1)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                
                var allEvents = _eventDetailService.TGetList().ToPagedList(page, 3);
                return View(allEvents);
            }
            else
            {
            
             var searchedEvents= _eventDetailService.SearchActivities(searchTerm);

                var pagedValues = searchedEvents.ToPagedList(page, 3);
                return View(pagedValues);
            }

    

            
        }
       

    }
}