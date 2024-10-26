using EntityLayer.Concrete;
using KidCamp.Areas.Instructor.Models;
using KidCamp.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace KidCamp.Areas.Instructor.Controllers
{ 
        [Area("Instructor")]
        [Route("Instructor/[controller]/[action]")]
        [Authorize(Roles = "Admin,Instructor")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

		
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			InstructorEditViewModel instructorEditViewModel = new InstructorEditViewModel();
			instructorEditViewModel.name = values.Name;
			instructorEditViewModel.surname = values.Surname;
			instructorEditViewModel.mail = values.Email;
            return View(instructorEditViewModel);



		}
        [HttpPost]
        public async Task<IActionResult> Index(InstructorEditViewModel b)
        {

            var instructor = await _userManager.FindByNameAsync(User.Identity.Name);
            

            instructor.Name = b.name;
            instructor.Surname = b.surname;
            instructor.PasswordHash = _userManager.PasswordHasher.HashPassword(instructor, b.password);
            var result = await _userManager.UpdateAsync(instructor);
            if (result.Succeeded)
            {
                return RedirectToAction("LoginInstructor", "Login");
            }
            return View();
        }

    }
}
