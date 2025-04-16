using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerModule.Core.Entities
{
    public class Customer : BaseEntity
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

        public Address BillingAddress { get; set; } = new Address();
        
        public Address ShippingAddress { get; set; } = new Address();

        [Range(0, double.MaxValue, ErrorMessage = "Credit Limit must be a positive number")]
        public decimal CreditLimit { get; set; }

        public string Notes { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}
