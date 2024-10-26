using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace KidCamp.ViewComponents.Default
{
    public class _Collaborate : ViewComponent
    {
        private readonly ICollaborateService _collaborateService;

        public _Collaborate(ICollaborateService collaborateService)
        {
            _collaborateService = collaborateService;
        }

        public IViewComponentResult Invoke()
        {
            var listCollaborate = _collaborateService.TGetList();
            return View(listCollaborate);
        }
    }
}
