using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KidCamp.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize(Roles = "Admin,Member")]
    public class ReservationController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IReservationService _reservationService;		
		private readonly UserManager<AppUser> _usermanager;

        public ReservationController(IEventDetailService eventDetailService, IReservationService reservationService, UserManager<AppUser> usermanager)
        {
            _eventDetailService = eventDetailService;
            _reservationService = reservationService;
            _usermanager = usermanager;
        }
        public async Task<IActionResult> AllReservations()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);

            var valueslist = _reservationService.GetAllReservations(values.Id);
            return View(valueslist);

        }
       

        [HttpGet]
        public IActionResult MakeReservation()
        {
            
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
        public async Task<IActionResult> MakeReservation(Reservation p)
		{

            var userId = _usermanager.GetUserId(User);           
            var appUser = await _usermanager.FindByIdAsync(userId);
         
            var roles = await _usermanager.GetRolesAsync(appUser); 
            if (roles.Contains("Member")) 
            {
                
                var eventDetail = _eventDetailService.TGetByID(p.EventDetailID);
                if (eventDetail != null)
                {
                   
                    if (appUser.ChildAge < eventDetail.MinAge || appUser.ChildAge > eventDetail.MaxAge)
                    {

                        
                        TempData["Warning"] = "Bu etkinliğe kayıt olabilmek için çocuğunuzun yaşı uygun değil.";

                        
                        List<SelectListItem> values = (from x in _eventDetailService.ListEventDetail()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.EventMaster.EventName,
                                                           Value = x.EventDetailID.ToString()
                                                       }).ToList();
                        ViewBag.v = values;
                        return View(p);                      

                    }
                }
            }


            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            var userId2 = user.Id;
            p.Status = "Onay Bekliyor";
            p.AppUserId = userId2;
            _reservationService.TAdd(p);
            return RedirectToAction("MakeReservation", "Reservation", new { area = "Member" });

        }
    }
    }
     
    

