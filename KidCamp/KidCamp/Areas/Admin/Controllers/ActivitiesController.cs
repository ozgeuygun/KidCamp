using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ActivitiesController : Controller
    {

     
        private readonly IEventDetailService _eventDetailService;
        private readonly IGenreService _genreService;
        private readonly IEventMasterService _eventMasterService;

        public ActivitiesController(IEventDetailService eventDetailService, IGenreService genreService, IEventMasterService eventMasterService)
        {
            _eventDetailService = eventDetailService;
            _genreService = genreService;
            _eventMasterService = eventMasterService;
        }

        public IActionResult Index()
        {
            var listDetail = _eventDetailService.TGetList();
			return View(listDetail);
        }
      

		[HttpGet]
        public IActionResult AddEvent()
        {
            List<SelectListItem> values = (from x in _genreService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.GenreName,
                                               Value = x.GenreID.ToString()
                                           }).ToList();
            ViewBag.v = values;


            List<SelectListItem> getName = (from x in _eventMasterService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.EventName,
                                               Value = x.EventMasterID.ToString()
                                           }).ToList();
            ViewBag.g = getName;
            return View();
            
        }
        [HttpPost]
        public IActionResult AddEvent(EventDetail eventDetail)
        {

           
          
        
            
            eventDetail.Status = true;
            _eventDetailService.TAdd(eventDetail);
			return RedirectToAction("Index");
            

           
        }
        
        public IActionResult DeleteEvent(int id)
        {
            
            var deleteDetail = _eventDetailService.TGetByID(id);
			if (deleteDetail != null)
			{
				deleteDetail.Status = false; 
				_eventDetailService.TUpdate(deleteDetail);
			}
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateEvent(int id)
        {

            var updateDetail = _eventDetailService.TGetByID(id);
            return View(updateDetail);
        }
        [HttpPost]
        public IActionResult UpdateEvent(EventDetail eventDetail)
		{ 
         
			var existingDetail = _eventDetailService.TGetByID(eventDetail.EventDetailID);

			if (existingDetail != null)
			{
                existingDetail.EventName = eventDetail.EventName;
				existingDetail.EventType = eventDetail.EventType;
				existingDetail.Location = eventDetail.Location;
				existingDetail.StartDate = eventDetail.StartDate;
				existingDetail.EndDate = eventDetail.EndDate;
				existingDetail.Price = eventDetail.Price;
				existingDetail.EventImage = eventDetail.EventImage;
				existingDetail.Description = eventDetail.Description;
				existingDetail.Capacity = eventDetail.Capacity;
				existingDetail.Participation = eventDetail.Participation;
				existingDetail.MinAge = eventDetail.MinAge;
                existingDetail.MaxAge = eventDetail.MaxAge;
           
				eventDetail.Status = true;
				
				_eventDetailService.TUpdate(existingDetail);
			}
			
			
			return RedirectToAction("Index");
		}
    }
}
