using FluentValidation;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Validations
{
    public class BookValidators : AbstractValidator<Book>
    {
        public BookValidators()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Kitap ismi boş bırakılamaz.");
            RuleFor(b => b.Name).MinimumLength(2).WithMessage("Kitap ismi en az 2 karakter içermeli.");

            RuleFor(b => b.NumberOfPage).NotEmpty().WithMessage("Sayfa sayısı boş bırakılamaz.");
            RuleFor(b => b.NumberOfPage).LessThanOrEqualTo(5000).WithMessage("Sayfa sayısı 5000'den daha büyük olamaz.");
        }
    }
}
