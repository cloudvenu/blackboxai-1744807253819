using CustomerModule.Core.Entities;
using CustomerModule.Shared.DTOs;

namespace CustomerModule.Shared.Mapping
{
    public static class MappingExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                CompanyName = customer.CompanyName,
                PhotoUrl = customer.PhotoUrl,
                BillingAddress = customer.BillingAddress.ToDto(),
                ShippingAddress = customer.ShippingAddress.ToDto(),
                CreditLimit = customer.CreditLimit,
                Notes = customer.Notes,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
                IsActive = customer.IsActive
            };
        }

        public static Customer ToEntity(this CreateCustomerDto dto)
        {
            return new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                CompanyName = dto.CompanyName,
                PhotoUrl = dto.PhotoUrl,
                BillingAddress = dto.BillingAddress.ToEntity(),
                ShippingAddress = dto.ShippingAddress.ToEntity(),
                CreditLimit = dto.CreditLimit,
                Notes = dto.Notes
            };
        }

        public static void UpdateFromDto(this Customer customer, UpdateCustomerDto dto)
        {
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.CompanyName = dto.CompanyName;
            customer.PhotoUrl = dto.PhotoUrl;
            customer.BillingAddress = dto.BillingAddress.ToEntity();
            customer.ShippingAddress = dto.ShippingAddress.ToEntity();
            customer.CreditLimit = dto.CreditLimit;
            customer.Notes = dto.Notes;
        }

        public static AddressDto ToDto(this Address address)
        {
            return new AddressDto
            {
                Street = address.Street,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
        }

        public static Address ToEntity(this AddressDto dto)
        {
            return new Address
            {
                Street = dto.Street,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
                Country = dto.Country
            };
        }
    }
}
