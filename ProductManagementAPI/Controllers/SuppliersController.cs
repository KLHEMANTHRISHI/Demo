using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagementAPI.DTO;
using ProductManagementAPI.Filters;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IValidator<SupplierDTO> _supplierValidator;

        public SuppliersController(ISupplierRepository supplierRepository,IValidator<SupplierDTO> validator)
        {
            _supplierRepository = supplierRepository;
            _supplierValidator = validator;
        }

        [ServiceFilter(typeof(CustomExceptionFilter))]
        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new InvalidOperationException("An unexpected error occurred!");
        }
        [LogActionFilter]
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllSuppliers();
                return Ok(suppliers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierDTO supplier)
        {
            
                var validationResult = _supplierValidator.Validate(supplier);
                if (!validationResult.IsValid)
                {

                    return BadRequest(validationResult.Errors);
                   
                   
                }
                await _supplierRepository.AddSupplier(supplier);
                return CreatedAtAction("AddSupplier", new { id = supplier.SupplierId }, supplier);
              

            
           
        }
    }
}
