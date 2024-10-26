using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]

    public class InstructorController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IReservationService _reservationService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;

        public InstructorController(IEventDetailService eventDetailService, IReservationService reservationService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _eventDetailService = eventDetailService;
            _reservationService = reservationService;
            _roleManager = roleManager;
            _userManager = userManager;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index() 
        {
            string roleId = "3"; 
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
               
                var roleName = role.Name;

             
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

                return View(usersInRole); 
            }

           
            return View(new List<AppUser>());
        }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            var edit = _appUserService.TGetByID(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult EditInstructor(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult InstructorAssignment()
        {
          
            var users = _userManager.Users.ToList();
            List<SelectListItem> values2 = users.Select(u => new SelectListItem
            {
                Text = u.UserName,
                Value = u.Id.ToString()
            }).ToList();

            ViewBag.UserList = values2;

          
            List<SelectListItem> values = (from x in _eventDetailService.ListEventDetail()
                                           select new SelectListItem
                                           {
                                               Text = x.EventMaster.EventName,
                                               Value = x.EventDetailID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();

        }

        
        [HttpPost]
        public IActionResult InstructorAssignment(Reservation p)
        {
           
            _reservationService.TAdd(p);
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });


        }

    }
}
