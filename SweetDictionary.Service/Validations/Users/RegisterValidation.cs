using FluentValidation;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Validations.Users;

public class RegisterValidation : AbstractValidator<RegisterRequestDto>
{
    public RegisterValidation()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatında değil.");
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Parola minimum 6 haneli olmalıdır.");
    }

}
