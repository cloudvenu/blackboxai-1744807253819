using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerModule.Core.Entities;

namespace CustomerModule.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByEmailAsync(string email);
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? excludeCustomerId = null);
        Task<IEnumerable<Customer>> SearchAsync(string searchTerm);
    }
}
