using DepositoHelados.Application.Services.EmployeeOrderProductService._01.Shared;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record UpdateOrderProductDto : IRequest<bool>
{
    public int Id { get; set; }
    public Guid PersonId { get; set; }

    public List<OrderProductDetailShared> ProductOrderItems { get; set; } = new();
}

