using ProductManagementAPI.DTO;

namespace ProductManagementAPI.Services
{
    public interface ISupplierRepository
    {
        Task<List<SupplierDTO>> GetAllSuppliers();
        Task AddSupplier(SupplierDTO supplier);
    }
}
