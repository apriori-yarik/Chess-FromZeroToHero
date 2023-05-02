using Chess_FromZeroToHero.Contracts.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Services.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Username).NotEmpty().MaximumLength(100);
            RuleFor(user => user.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(user => user.LastName).NotEmpty().MaximumLength(100);
            RuleFor(user => user.BirthDate).NotNull();
        }
    }
}
