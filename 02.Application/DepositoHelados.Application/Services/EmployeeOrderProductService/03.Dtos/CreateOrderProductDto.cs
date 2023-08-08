using DepositoHelados.Application.Services.EmployeeOrderProductService._01.Shared;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record CreateOrderProductDto : IRequest<bool>
{
    public Guid PersonId { get; set; }
    public int CampusId { get; set; }

    public List<OrderProductDetailShared> ProductOrderItems { get; set; } = new();
}

