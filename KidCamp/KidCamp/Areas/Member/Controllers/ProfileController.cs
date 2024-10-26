using EntityLayer.Concrete;
using KidCamp.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
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
            MemberEditViewModel memberEditViewModel = new MemberEditViewModel();
            memberEditViewModel.name = values.Name;
            memberEditViewModel.surname = values.Surname;
            memberEditViewModel.mail = values.Email;
            memberEditViewModel.childage = values.ChildAge;
            return View(memberEditViewModel);



        }

        [HttpPost]
        public async Task<IActionResult> Index(MemberEditViewModel p)
        { 
            
            var member = await _userManager.FindByNameAsync(User.Identity.Name);
            
                member.Name = p.name;
                member.Surname = p.surname;
                member.ChildAge = p.childage;
                member.PasswordHash = _userManager.PasswordHasher.HashPassword(member, p.password);
                var result = await _userManager.UpdateAsync(member);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                return View();
            }



        }
    }

