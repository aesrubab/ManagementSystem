using AutoMapper;
using ManagementSystem.Application.CQRS.Categories.Commands.Requests;
using ManagementSystem.Application.CQRS.Categories.Commands.Responses;
using ManagementSystem.Application.CQRS.Categories.Queries.Responses;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Application.CQRS.Customers.Queries.Responses;
using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Application.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryRequest , Category>().ReverseMap();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap< Category , GetAllCategoryResponse>();


        CreateMap<CreateCustomerRequest, Customer>().ReverseMap();
        CreateMap<Customer, CreateCustomerResponse>();
        CreateMap<Customer, GetAllCustomerResponse>();
    }
}