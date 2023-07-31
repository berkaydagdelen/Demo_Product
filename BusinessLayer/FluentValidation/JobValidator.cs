using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithMessage("Ad Boş Geçilemez");
            RuleFor(x => x.NAME).MinimumLength(3).WithMessage("Ad En Az 3 Karakter Olmalıdır");
        }
    }
}
