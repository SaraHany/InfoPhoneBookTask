using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook
{
    public class CreatePhoneBookCommandValidator : AbstractValidator<CreatePhoneBookCommand>
    {
        public CreatePhoneBookCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);
            RuleFor(p => p.PhonNumber)
                .NotEmpty()
                .NotNull();
        }
    }
}
