using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerModule.Core.Entities;
using CustomerModule.Core.Interfaces;
using CustomerModule.Infrastructure.Data;

namespace CustomerModule.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Where(c => c.IsActive)
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email && c.IsActive);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            customer.IsActive = true;
            
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (existingCustomer == null)
                throw new KeyNotFoundException($"Customer with ID {customer.Id} not found.");

            customer.UpdatedAt = DateTime.UtcNow;
            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found.");

            customer.IsActive = false;
            customer.UpdatedAt = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeCustomerId = null)
        {
            var query = _context.Customers
                .Where(c => c.Email == email && c.IsActive);

            if (excludeCustomerId.HasValue)
                query = query.Where(c => c.Id != excludeCustomerId.Value);

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm)
        {
            return await _context.Customers
                .Where(c => c.IsActive &&
                    (c.FirstName.Contains(searchTerm) ||
                     c.LastName.Contains(searchTerm) ||
                     c.Email.Contains(searchTerm) ||
                     c.CompanyName.Contains(searchTerm)))
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToListAsync();
        }
    }
}
