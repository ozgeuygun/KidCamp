using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidCamp.Areas.Member.Controllers
{ 
        [Area("Member")]
        [Route("Member/[controller]/[action]")]
        [Authorize(Roles = "Admin,Member")]
    public class CommentController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly ITestimonialService _testimonialService;
        private readonly UserManager<AppUser> _usermanager;

        public CommentController(IEventDetailService eventDetailService, ITestimonialService testimonialService, UserManager<AppUser> usermanager)
        {
            _eventDetailService = eventDetailService;
            _testimonialService = testimonialService;
            _usermanager = usermanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in _eventDetailService.ListEventDetail()
                                           select new SelectListItem
                                           {
                                               Text = x.EventMaster.EventName,
                                               Value = x.EventDetailID.ToString()
                                           }).ToList();
            ViewBag.v = values;          
            return View();
        }

        [HttpPost]
        public IActionResult Index(Testimonial testimonial)
        {
                     

            var user =  _usermanager.FindByNameAsync(User.Identity.Name);
            var userId2 = user.Id;      
            testimonial.AppUserId = userId2;
           
            try
            {
                _testimonialService.TAdd(testimonial);
                TempData["SuccessMessage"] = "Yorum başarıyla eklendi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Yorum eklenirken bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction("Index");
            
          
        }
       
    }
}
