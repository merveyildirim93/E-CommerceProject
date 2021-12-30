using AutoMapper;
using E_Commerce.Api.Dtos.ProductDto;
using E_Commerce.Data.Models;

namespace E_Commerce.Api.Helper
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(x => x.productBrand, o => o.MapFrom(s => s.productBrand.Brand))
                .ForMember(x => x.productType, o => o.MapFrom(s => s.productType.Type))
                .ForMember(x => x.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
