using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class EventMasterController : Controller
    {
        private readonly IEventMasterService _eventMasterService;

        public EventMasterController(IEventMasterService eventMasterService)
        {
            _eventMasterService = eventMasterService;
        }

        public IActionResult Index()
        {
            var listName = _eventMasterService.TGetList();
            return View(listName);
        }
        [HttpGet]
        public IActionResult AddName()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddName(EventMaster eventMaster)
        {
            if (!ModelState.IsValid)
            {
                return View(eventMaster); 
            }
            eventMaster.Status = true;
            _eventMasterService.TAdd(eventMaster);
            return RedirectToAction("Index");
        }

      
        public IActionResult DeleteName(int id)
        {
             var deleteName = _eventMasterService.TGetByID(id);
	     if (deleteName != null)
	     {
		deleteName.Status = false;
		_eventMasterService.TUpdate(deleteName); 
	     }
	       return RedirectToAction("Index","Activities", new { area = "Admin" });
	}

        [HttpGet]
        public IActionResult UpdateName(int id)
        {

            var updateName = _eventMasterService.TGetByID(id);
            return View(updateName);
        }
        [HttpPost]
        public IActionResult UpdateName(EventMaster eventMaster)
        {
            eventMaster.Status = true;
	   _eventMasterService.TUpdate(eventMaster);
	return RedirectToAction("Index", "Activities", new { area = "Admin" });
	}
    }
}
