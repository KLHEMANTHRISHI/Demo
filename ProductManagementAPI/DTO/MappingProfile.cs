using AutoMapper;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Supplier,SupplierDTO>().ReverseMap();
        }
    }
}
