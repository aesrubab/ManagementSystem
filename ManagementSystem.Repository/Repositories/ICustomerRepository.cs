using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Repository.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    void UpdateAsync(Customer customer);
    Task<bool> Delete(int id, int deletedBy);
    IQueryable<Customer> GetAll();
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllInitialData();
    Task DeleteAsync(Customer customer);
}