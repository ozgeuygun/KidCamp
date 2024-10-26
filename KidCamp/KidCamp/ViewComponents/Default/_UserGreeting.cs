
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _UserGreeting:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UserGreeting(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var userName = user.Name;
                return View("Default", userName); 
            }
            return View();
         
        }
    }
}
