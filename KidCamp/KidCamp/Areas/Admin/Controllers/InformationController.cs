using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class InformationController : Controller
    {
        private readonly IActivityInformationService _activityInformationService;

        public InformationController(IActivityInformationService activityInformationService)
        {
            _activityInformationService = activityInformationService;
        }

        public IActionResult Index()
        {
            var listInformation = _activityInformationService.TGetList();
            return View(listInformation);
        }
        public IActionResult DeleteInfo(int id)
        {
            var info = _activityInformationService.TGetByID(id);

            if (info != null)
            {
                _activityInformationService.TDelete(info);
                TempData["SuccessMessage"] = "Silme islemi basarili!";
            }
            else
            {
                TempData["ErrorMessage"] = "Silinecek bilgi bulunamadı.";
            }

            var listInformation = _activityInformationService.TGetList();
            return View("Index", listInformation);

        }
    }
}
