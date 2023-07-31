using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithMessage("Ad Boş Geçemezsiniz");
            RuleFor(x => x.NAME).MinimumLength(3).WithMessage("Ad En Az 3 Karakter Olmalıdır");

        }
    }
}
