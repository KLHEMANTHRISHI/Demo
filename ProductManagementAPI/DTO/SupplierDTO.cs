using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }

        [Required]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Company Name is Invalid: Company Name should have the minimum length 5 and maximum length of 50")]
        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? HomePage { get; set; }
    }
}
