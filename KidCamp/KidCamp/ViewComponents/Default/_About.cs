using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _About : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _About(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var listAbout = _aboutService.TGetList();
            return View(listAbout);
        }
    }
}
