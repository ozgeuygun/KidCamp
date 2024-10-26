using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ReservationValidator:AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Participant).NotEmpty().WithMessage("Katılımcı kısmını boş geçemezsiniz!");
            RuleFor(x => x.ApplicationDate).NotEmpty().WithMessage("Başvuru tarihi kısmını boş geçemezsiniz!");
            RuleFor(x => x.EventDetailID).NotEmpty().WithMessage("etkinlik kısmını boş geçemezsiniz!");
        }
    }
}
