using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidCamp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public ReservationController(IEventDetailService eventDetailService, IReservationService reservationService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _eventDetailService = eventDetailService;
            _reservationService = reservationService;
            _userManager = userManager;
            _roleManager = roleManager;
        }



       
        public IActionResult Index()
        {
           

            var list = _reservationService.GetUserReservationsByEvent();
         
            return View(list);

        }
        [HttpGet]

        public IActionResult UpdateReservation(int id)
        {

            var values = _reservationService.TGetByID(id);
            values.AppUser = _userManager.FindByIdAsync(values.AppUserId.ToString()).Result;
            values.EventDetail = _eventDetailService.TGetByID(values.EventDetailID);
            return View(values);
        }
        
      
        [HttpPost]
        public IActionResult UpdateReservation(Reservation reservation)
        {
            
            var existingReservation = _reservationService.TGetByID(reservation.ReservationID);           
            existingReservation.Status = reservation.Status;         
            _reservationService.TUpdate(existingReservation);         
            ViewBag.SuccessMessage = "Başarıyla güncellendi.";
            return View(existingReservation);
          
        }
       


    }
}
