using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TestimonialValidator:AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum kısmını boş geçemezsiniz!");
            RuleFor(x => x.EventDetailID).NotEmpty().WithMessage("Etkinlik kısmını boş geçemezsiniz!");
            RuleFor(x => x.ClientName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz!");
            RuleFor(x => x.ClientDetail).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz!");
            
        }
    }
}
