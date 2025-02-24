using FluentValidation;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.CQRS.Customers.Validators;

public sealed class DeleteCustomerValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("Id musbet eded olmalidi");

       
    }
}