using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;


namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandler;

public class UpdateCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerRequest, Result<UpdateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork=unitOfWork;

    public async Task<Result<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            return new Result<UpdateCustomerResponse>
            {
                IsSuccess = false,
                Errors = []
            };
        }

        customer.Name = request.Name;
        customer.Email = request.Email;


        var response = new UpdateCustomerResponse
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };

        return new Result<UpdateCustomerResponse>
        {
            Data = response,
            IsSuccess = true
        };
    }
}