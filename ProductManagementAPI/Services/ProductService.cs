using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.DTO;
using ProductManagementAPI.Models;
using System.Net.Http.Headers;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductRepository
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;
        public ProductService(NorthwindContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> GetProducts()
        {
            var productList = await _context.Products.ToListAsync();
            var productDTOList = _mapper.Map<List<ProductDTO>>(productList);
            return productDTOList;

        }
        public async Task AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
             var product = await _context.Products.FindAsync(id);
            if(product ==null)
            { 
                return null;
            }

            var productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

     
        public async Task UpdateProduct(int ProductId, Product product)
        {
            var productData = await _context.Products.FindAsync(ProductId);
           
            //   _context.Products.Update(product);

            if(productData !=null)
            {
                _context.Entry(productData).CurrentValues.SetValues(product);
            }
            //use update by entity state.modify the state of the entity
            //_context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges();



        }


        //Discontinued Product

         public async Task<List<ProductDTO>> DiscontinuedProduct()
        {
            var productList = await _context.Products.Where(p => p.Discontinued == true).ToListAsync();

            var productDTOList = _mapper.Map<List<ProductDTO>>(productList);

            return productDTOList;
        }
    }
}
