using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerModule.Shared.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Company Name cannot be longer than 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; }

        [Required(ErrorMessage = "Billing Address is required")]
        public AddressDto BillingAddress { get; set; } = new AddressDto();

        public AddressDto ShippingAddress { get; set; } = new AddressDto();

        [Range(0, double.MaxValue, ErrorMessage = "Credit Limit must be a positive number")]
        public decimal CreditLimit { get; set; }

        public string Notes { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();
    }

    public class CreateCustomerDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Company Name cannot be longer than 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; }

        [Required(ErrorMessage = "Billing Address is required")]
        public AddressDto BillingAddress { get; set; } = new AddressDto();

        public AddressDto ShippingAddress { get; set; } = new AddressDto();

        [Range(0, double.MaxValue, ErrorMessage = "Credit Limit must be a positive number")]
        public decimal CreditLimit { get; set; }

        public string Notes { get; set; } = string.Empty;
    }

    public class UpdateCustomerDto : CreateCustomerDto
    {
        [Required(ErrorMessage = "Customer ID is required")]
        public int Id { get; set; }
    }
}
