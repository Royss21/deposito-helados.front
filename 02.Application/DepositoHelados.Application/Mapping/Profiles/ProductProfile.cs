
using DepositoHelados.Application.Services.ProductService.Dtos;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Application.Mapping.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
    }
}

