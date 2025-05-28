using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public List<Testimonial> GetUnapprovedEventTestimonials()
        {
            using (var context = new Context())
            {
                return context.Testimonials.Include(x => x.EventDetail).Include(x => x.AppUser).Where(x => x.Status == false).ToList();
            }
        }

        public List<Testimonial> GetPublishedUserEventTestimonials()
        {
            using (var context = new Context())
            {
                return context.Testimonials.Include(x => x.EventDetail).Include(x => x.AppUser).Where(x => x.Status == true).ToList();
            }
        }
    }
}
