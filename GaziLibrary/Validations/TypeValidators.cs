using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Validations
{
    public class TypeValidators : AbstractValidator<Entities.Concrete.Type>
    {
        public TypeValidators()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Tür ismi boş bırakılamaz.");
            RuleFor(t => t.Name).MinimumLength(2).WithMessage("Tür ismi en az 2 karakter içermelidir.");
        }
    }
}
