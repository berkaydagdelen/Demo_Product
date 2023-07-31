using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithMessage("Ürün Adını Boş Geçemezsiniz");
            RuleFor(x => x.NAME).MinimumLength(3).WithMessage("Ürün Adı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.STOCK).NotEmpty().WithMessage("Stok Sayısı Boş Geçemezsiniz");
            RuleFor(x => x.PRICE).NotEmpty().WithMessage("Fiyat Boş Geçemezsiniz");
        }
    }
}
