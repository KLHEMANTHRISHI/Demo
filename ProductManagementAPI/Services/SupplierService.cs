using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.DTO;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class SupplierService : ISupplierRepository
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;
        public SupplierService(NorthwindContext context,IMapper mapper) {
            _context = context;
            _mapper = mapper;
        
        }

        public async Task<List<SupplierDTO>> GetAllSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return _mapper.Map<List<SupplierDTO>>(suppliers);
        }
        public async Task AddSupplier(SupplierDTO supplier)
        {
            var supplierData = _mapper.Map<Supplier>(supplier);
            _context.Suppliers.Add(supplierData);
            await _context.SaveChangesAsync();
        }
    }
}
