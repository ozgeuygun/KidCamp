using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Admin,Member")]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteActivityService _favoriteActivityService;
        private readonly UserManager<AppUser> _usermanager;

        public FavoriteController(IFavoriteActivityService favoriteActivityService, UserManager<AppUser> usermanager)
        {
            _favoriteActivityService = favoriteActivityService;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            var valueslist = _favoriteActivityService.GetAllFavorities(values.Id);
            return View(valueslist);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavorities(FavoriteActivity f)
        {


            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            f.AppUserId = user.Id;
            _favoriteActivityService.TAdd(f);            
            TempData["SuccessMessage"] = "Etkinlik favorilere eklendi!";
            return RedirectToAction("Index", "Activities", new { area = "Member" });
        }

       
        public async Task<IActionResult> RemoveFavorities(int id)
        {
           
            var user = await  _usermanager.FindByNameAsync(User.Identity.Name);

            var favoriteActivity = _favoriteActivityService.TGetByID(id);

           
            if (favoriteActivity != null && favoriteActivity.AppUserId == user.Id)
            {
               
                _favoriteActivityService.TDelete(favoriteActivity);
                TempData["SuccessMessage"] = "Etkinlik favorilerden basariyla kaldirildi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Etkinlik bulunamadı veya erisim izniniz yok!";
            }

            return RedirectToAction("Index", "Activities", new { area = "Member" });

        }

    }
}
