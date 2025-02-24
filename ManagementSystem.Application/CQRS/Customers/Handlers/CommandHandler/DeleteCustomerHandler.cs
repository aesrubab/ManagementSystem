using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandler;

public class DeleteCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerRequest, Result<DeleteCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result<DeleteCustomerResponse>> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var deleted = await _unitOfWork.CustomerRepository.Delete(request.Id, request.DeletedBy);

        if (!deleted)
        {
            return new Result<DeleteCustomerResponse>
            {
                Data = null,
                Errors = ["Musteri tapilmadi"],
                IsSuccess = false
            };
        }

        return new Result<DeleteCustomerResponse>
        {
            Data = new DeleteCustomerResponse { Id = request.Id },
            Errors = [],
            IsSuccess = true
        };
    }
}

