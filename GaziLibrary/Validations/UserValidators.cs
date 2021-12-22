using FluentValidation;
using GaziLibrary.Business.Concrete;
using GaziLibrary.DataAccess.Concrete;
using GaziLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaziLibrary.Validations
{
    public class UserValidators : AbstractValidator<User>
    {
        public UserValidators()
        {
            // User Name
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(u => u.UserName).GreaterThan("5").WithMessage("Kullanıcı adı en az 6 haneli olmalıdır.");
            RuleFor(u => u.UserName).Must(UniqueUsername).WithMessage("Kullanıcı adı zaten mevcut.");

            //First Name
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakter içermelidir.");

            // Last Name
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 karakter içermelidir.");

            // Password
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(u => u.Password).GreaterThan("5").WithMessage("Şifre en az 6 haneli olmalıdır.");

            // Email
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email adresini düzgün giriniz.");
        }
        private bool UniqueUsername(string arg)
        {
            var userManager = new UserManager(new EfUserDal());
            return userManager.CheckUsername(arg).Success;
        }
    }
}
