using System.ComponentModel.DataAnnotations;

namespace CustomerModule.Shared.DTOs
{
    public class AddressDto
    {
        [Required(ErrorMessage = "Street is required")]
        [StringLength(100, ErrorMessage = "Street cannot be longer than 100 characters")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string City { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(20, ErrorMessage = "Postal Code cannot be longer than 20 characters")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        public string Country { get; set; } = string.Empty;

        public string FullAddress => $"{Street}, {City}, {State} {PostalCode}, {Country}".TrimEnd(',', ' ');
    }
}
