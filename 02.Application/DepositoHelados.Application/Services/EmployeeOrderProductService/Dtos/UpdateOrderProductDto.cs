namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record UpdateOrderProductDto : IRequest<bool>
{
    public int Id { get; set; }
    public Guid PersonId { get; set; }

    public List<OrderProductDetailDto> ProductOrderItems { get; set; } = new();
}

