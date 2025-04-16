using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerModule.Core.Interfaces;
using CustomerModule.Core.Services;
using CustomerModule.Infrastructure.Data;
using CustomerModule.Infrastructure.Repositories;

namespace CustomerModule.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomerModule(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Register services
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
