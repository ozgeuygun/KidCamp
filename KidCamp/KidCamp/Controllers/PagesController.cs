using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        public IActionResult Facility()
        {
            return View();
        }
        public IActionResult PopularInstructors()
        {
            return View();
        }
        public IActionResult Collaborate()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
    }
}
