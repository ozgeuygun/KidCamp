using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MasterValidator:AbstractValidator<EventMaster>
    {
        public MasterValidator()
        {
            RuleFor(x => x.EventName).NotEmpty().WithMessage("Bu kısmı boş geçemezsiniz!");
        }
    }
}
