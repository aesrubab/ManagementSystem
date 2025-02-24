using AutoMapper;
using FluentValidation;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer newCustomer = _mapper.Map<Customer>(request);

            await _unitOfWork.CustomerRepository.AddAsync(newCustomer);

            CreateCustomerResponse response = _mapper.Map<CreateCustomerResponse>(newCustomer);

            return new Result<CreateCustomerResponse>()
            {
                Data = response,
                Errors = new List<string>(),  
                IsSuccess = true
            };
        }
    }
}
