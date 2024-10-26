using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using KidCamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager; 
        private readonly SignInManager<AppUser> _signInManager; 
        private readonly RoleManager<AppRole> _roleManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
		{
			if (!ModelState.IsValid) 
			{
				return View(p); 
			}

			AppUser appUser = new AppUser()
			{
				Name = p.RegisterName,
				Surname = p.RegisterSurname,
				UserName = p.Username,
				Email = p.RegisterMail,
				ChildName = p.RegisterChildName,
				ChildAge = p.RegisterChildAge
			};
			if (p.Password == p.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, p.Password);
				if (result.Succeeded)
				{
					string roleId = "2";
					var role = await _roleManager.FindByIdAsync(roleId);
					if (role != null)
					{
						string roleName = role.Name;
						await _userManager.AddToRoleAsync(appUser, roleName);
						return RedirectToAction("SignIn");
					}

				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(p);

		}

        [HttpGet]
        public IActionResult SignIn()
		{
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel p)
		{
 
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "Member" });
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Register(InstructorRegisterViewModel b)
		{
			if (!ModelState.IsValid) 
			{
				return View(b); 
			}

			AppUser appUser = new AppUser()
			{
				Name = b.RegisterName,
				Surname = b.RegisterSurname,
				UserName = b.Username,
				Email = b.RegisterMail,
				
			};
			if (b.Password == b.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, b.Password);
				if (result.Succeeded)
				{
					string roleId = "3";
					var role = await _roleManager.FindByIdAsync(roleId);
					if (role != null)
					{
						string roleName = role.Name;
						await _userManager.AddToRoleAsync(appUser, roleName);
						return RedirectToAction("SignIn");
					}

				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(b);

		}

        [HttpGet]
        public IActionResult LoginInstructor()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> LoginInstructor(UserSignInViewModel e)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(e.Username, e.Password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Profile", new { area = "Instructor" });
				}
				else
				{
					return RedirectToAction("SignIn", "Login");
				}
			}
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

