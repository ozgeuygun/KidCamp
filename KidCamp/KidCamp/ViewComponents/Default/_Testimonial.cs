﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _Testimonial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.GetPublishedUserEventTestimonials();
            return View(values);
        }
    }
}
