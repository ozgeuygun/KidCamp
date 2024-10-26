using BusinessLayer.Abstract;
using ClosedXML.Excel;
using EntityLayer.Concrete;
using KidCamp.Areas.Instructor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace KidCamp.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    [Authorize(Roles = "Admin,Instructor")]
    public class InstructorEventController : Controller
    {
        private readonly IEventDetailService _eventDetailService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _usermanager;

        public InstructorEventController(IEventDetailService eventDetailService, IReservationService reservationService, UserManager<AppUser> usermanager)
        {
            _eventDetailService = eventDetailService;
            _reservationService = reservationService;
            _usermanager = usermanager;
        }

      
     
        [HttpGet]
        public async Task<IActionResult> Event()
        {
           
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                
                return RedirectToAction("SignIn", "Account");
            }
         
            var user = await _usermanager.FindByNameAsync(username);

            if (user == null)
            {
           
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(new List<Reservation>());
            }

            
            var userId = user.Id;           
            var reservations = _reservationService.GetAssignedEventNamesForInstructor(userId);
            return View(reservations);
            
        }



        [HttpGet]

        public async Task<IActionResult> Details(int id)

        {
            
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("SignIn", "Account");
            }

            var user = await _usermanager.FindByNameAsync(username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(new List<Reservation>());
            }

            var userId = user.Id;           
            var reservations = _reservationService.GetReservationsByEventDetailIdAsync(id);
            var filteredReservations = reservations
                .Where(r => r.AppUserId != userId) 
                .ToList();


            if (filteredReservations == null || !filteredReservations.Any())
            {
                ModelState.AddModelError(string.Empty, "Katılımcı bulunamadı.");
                return View(new List<Reservation>());
            }

            return View(filteredReservations);

          
        }
       
        public async Task<IActionResult> ExcelReport(int id)
        {

            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("SignIn", "Account");
            }

           
            var user = await _usermanager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            var userId = user.Id;          
            var allReservations = _reservationService.GetReservationsByEventDetailIdAsync(id);
            var filteredReservations = allReservations.Where(r => r.AppUserId != userId).ToList();

            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Katılımcı Listesi");
                workSheet.Cell(1, 1).Value = "Velinin Adı Soyadı";
                workSheet.Cell(1, 2).Value = "Çocuğun Adı";
                workSheet.Cell(1, 3).Value = "Veli İrtibat";

                int rowCount = 2;
                foreach (var item in filteredReservations)
                {
                    
                    if (item.AppUser != null)
                    {
                        workSheet.Cell(rowCount, 1).Value = $"{item.AppUser.Name} {item.AppUser.Surname}";
                        workSheet.Cell(rowCount, 2).Value = item.AppUser.ChildName;
                        workSheet.Cell(rowCount, 3).Value = item.AppUser.Email;
                        rowCount++;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Liste.xlsx");
                }


            }
        }
        }
    }

   


