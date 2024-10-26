using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public CommentController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
    
     
        public IActionResult Index()
        {
            var listComment = _testimonialService.GetUnapprovedEventTestimonials();
            ViewBag.SuccessMessage = TempData["SuccessMessage"]; 
            return View(listComment);
        }
        
      
        [HttpPost]
        public IActionResult Confirm(Testimonial testimonial)
        {
            
            var existingTestimonial = _testimonialService.TGetByID(testimonial.TestimonialID);

            if (existingTestimonial != null)
            {
               
                existingTestimonial.Status = true; 

                
                _testimonialService.TUpdate(existingTestimonial);
            
            }

         
            return RedirectToAction("Index", "Activities", new { area = "Admin" });
        }
     

    }
}
