using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var listContact = _contactService.TGetList();
            return View(listContact);
        }
        public IActionResult DeleteContact(int id)
        {
       
            var deleteContact = _contactService.TGetByID(id);
            _contactService.TDelete(deleteContact);
            return RedirectToAction("Index");
        }
    }
}
