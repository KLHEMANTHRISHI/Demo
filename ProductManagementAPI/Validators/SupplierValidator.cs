using FluentValidation;
using ProductManagementAPI.DTO;

namespace ProductManagementAPI.Validators
{
    public class SupplierDTOValidator :AbstractValidator<SupplierDTO>
    {
        public SupplierDTOValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is required");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Contact Name is required").MinimumLength(5).WithMessage("Contact Name should have the minimum length 5");
            RuleFor(x => x.ContactTitle).NotEmpty().WithMessage("Contact Title is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required").MaximumLength(50).WithMessage("Address should have the maximum length 50");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
           
       
        }
    }
    
}
