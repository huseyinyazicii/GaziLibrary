using FluentValidation;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Validations
{
    public class MessageValidators : AbstractValidator<Message>
    {
        public MessageValidators()
        {
            RuleFor(m => m.Text).NotEmpty().WithMessage("Mesaj kısmı boş bırakılamaz.");
            RuleFor(m => m.Text).MinimumLength(30).WithMessage("Mesaj kısmı en az 30 karakter içermelidir.");
            RuleFor(m => m.Text).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz.");
        }
    }
}
