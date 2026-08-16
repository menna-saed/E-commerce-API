using Ecommerce.Application.Brands.Dtos;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Types.Dtos;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.Application;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>()
            .Map(dest => dest.ProductBrand, src => src.ProductBrand.Name)
            .Map(dest => dest.ProductType, src => src.ProductType.Name);
       config.NewConfig<ProductBrand, BrandDto>();
       config.NewConfig<ProductType, TypeDto>();
       
    }
}