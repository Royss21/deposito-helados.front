using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Application.Mapping.Profiles
{
    public  class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //CreateMap<EmployeeOrderProduct, GetOrderProductWithoutOrderDto>()
            //.ForMember(x => x.DateOrderProduct, m => m.MapFrom(d => d.DateProductOrder))
            //.ForMember(x => x.ProductOrderItems, m => m.MapFrom(d => d.EmployeeProductOrderDetails.Select(s => new GetOrderProductDetailDto
            //{
            //    Product = s.Product.Name,
            //    UnitMeasurement = s.MdUnitMeasurement.Name,
            //    Quantity = s.Quantity,
            //    MdUnitMeasurementId = s.MdUnitMeasurement.Id,
            //    ProductId = s.ProductId
            //})));

        }
    }
}
