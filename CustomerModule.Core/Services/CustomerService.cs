using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerModule.Core.Entities;
using CustomerModule.Core.Interfaces;

namespace CustomerModule.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (await _customerRepository.EmailExistsAsync(customer.Email))
                throw new InvalidOperationException($"A customer with email {customer.Email} already exists.");

            ValidateCustomer(customer);
            
            return await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (await _customerRepository.EmailExistsAsync(customer.Email, customer.Id))
                throw new InvalidOperationException($"A customer with email {customer.Email} already exists.");

            ValidateCustomer(customer);
            
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllCustomersAsync();

            return await _customerRepository.SearchAsync(searchTerm);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeCustomerId = null)
        {
            return !await _customerRepository.EmailExistsAsync(email, excludeCustomerId);
        }

        private void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(customer.LastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new ArgumentException("Email is required.");

            if (customer.CreditLimit < 0)
                throw new ArgumentException("Credit limit cannot be negative.");

            // Validate BillingAddress
            if (customer.BillingAddress != null)
            {
                if (string.IsNullOrWhiteSpace(customer.BillingAddress.Street))
                    throw new ArgumentException("Billing street address is required.");
                if (string.IsNullOrWhiteSpace(customer.BillingAddress.City))
                    throw new ArgumentException("Billing city is required.");
                if (string.IsNullOrWhiteSpace(customer.BillingAddress.Country))
                    throw new ArgumentException("Billing country is required.");
            }

            // Validate ShippingAddress if different from BillingAddress
            if (customer.ShippingAddress != null)
            {
                if (string.IsNullOrWhiteSpace(customer.ShippingAddress.Street))
                    throw new ArgumentException("Shipping street address is required.");
                if (string.IsNullOrWhiteSpace(customer.ShippingAddress.City))
                    throw new ArgumentException("Shipping city is required.");
                if (string.IsNullOrWhiteSpace(customer.ShippingAddress.Country))
                    throw new ArgumentException("Shipping country is required.");
            }
        }
    }
}
