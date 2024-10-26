using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
