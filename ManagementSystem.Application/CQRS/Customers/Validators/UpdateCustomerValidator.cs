using FluentValidation;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.CQRS.Customers.Validators;

public sealed class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("Id musbet eded olmalidir");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Ad bos ola bilmez")
            .MaximumLength(255).WithMessage("Ad max 255 harf ola biler");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email bos ola bilmez")
            .EmailAddress().WithMessage("Emaili duzgun daxil et")
            .MaximumLength(255).WithMessage("Email en cox 255 harf ola biler");
    }
}