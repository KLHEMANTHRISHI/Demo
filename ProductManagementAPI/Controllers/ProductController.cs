using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTO;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        //DI
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        ////Normal Methods
        //public string Message()
        //{
        //    return "Hello from Product Controller";
        //}


        //Action Methods
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok("Today is a good day");
        }
       

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                List<ProductDTO> products = await _productRepository.GetProducts();
                return Ok(products);
            }
             catch(Exception e)
            {
               // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
               return BadRequest(e.Message);
            }
           
        }


        //GetProductById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                ProductDTO product = await _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GetProductById as queryString
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById([FromQuery] int id)
        {
            try
            {
                ProductDTO product = await _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //AddProduct
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                else if(!ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

               await _productRepository.AddProduct(product);
                return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //Both user and admin can access
        [Authorize(Roles = "admin,user")]
        //call the update method
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,Product product)
        {
            try
            {
                await _productRepository.UpdateProduct(id, product);
            }
           catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpGet("DiscontinuedProduct")]
        public async Task<IActionResult> AllDiscontinuedProduct()
        {
            try
            {
                List<ProductDTO> productList = await _productRepository.DiscontinuedProduct();
                 
                return Ok(productList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
