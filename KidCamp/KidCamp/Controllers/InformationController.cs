using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Controllers
{
	[AllowAnonymous]
	public class InformationController : Controller
	{
		private readonly IActivityInformationService _activityInformationService;

		public InformationController(IActivityInformationService activityInformationService)
		{
			_activityInformationService = activityInformationService;
		}
		[HttpGet]
		public IActionResult RequestForm()
		{
            return View();
        }
		[HttpPost]
		public IActionResult RequestForm(ActivityInformation f)
		{
			_activityInformationService.TAdd(f);
            return Json(new { success = true });
        }
	}
}
