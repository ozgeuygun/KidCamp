using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _Facilities:ViewComponent
    {
        private readonly IFacilityService _facilityService;

        public _Facilities(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        public IViewComponentResult Invoke() 
        {
            var listFacility = _facilityService.TGetList();
            return View(listFacility);
        }

    }
}
