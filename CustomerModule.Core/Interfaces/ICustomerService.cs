using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerModule.Core.Entities;

namespace CustomerModule.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
        Task<bool> IsEmailUniqueAsync(string email, int? excludeCustomerId = null);
    }
}
