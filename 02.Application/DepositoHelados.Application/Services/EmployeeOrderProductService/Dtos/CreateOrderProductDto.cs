namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record CreateOrderProductDto : IRequest<bool>
{
    public Guid PersonId { get; set; }
    public int CampusId { get; set; }

    public List<OrderProductDetailDto> ProductOrderItems { get; set; } = new();
}

