using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Controllers
{
	[AllowAnonymous]

	public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
