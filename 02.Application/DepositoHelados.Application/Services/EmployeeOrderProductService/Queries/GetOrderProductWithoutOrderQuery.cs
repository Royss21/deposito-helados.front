using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Queries
{
    public record GetOrderProductWithoutOrderQuery : IRequest<List<GetOrderProductDto>>
    {
        public Guid PersonId { get; set; }
    }

}
