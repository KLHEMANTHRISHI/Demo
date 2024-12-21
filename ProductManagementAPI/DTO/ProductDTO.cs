using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class ProductDTO 
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is Required!!")]
        public string ProductName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Quantity Per Unit is Required!!")]
        public string? QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "Unit Price is Required!!")]
        [IsNonNegativeValueValidator]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        

    }

    //custom Validation
    class IsNonNegativeValueValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                decimal unitPrice = (decimal)value;
                if (unitPrice < 0)
                {
                    return new ValidationResult("Unit Price should be a non-negative value");
                }
            }
            return ValidationResult.Success;
        }
    }
}
