using ProductManagementAPI.DTO;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductRepository
    {
        //List<Product> GetProducts();
        Task <List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO product);
        Task UpdateProduct(int ProductId,Product product);
        Task <List<ProductDTO>> DiscontinuedProduct();

        

            
    }
}
