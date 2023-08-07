namespace DepositoHelados.Application.Services.OrderService._03.Dtos;

public record GetLastOrderDto
{
    public Guid Id { get; set; }
    public string Person { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}


public record GetLastOrderDetailDto
{
    public string Product { get; set; }
    public Guid ProductId { get; set; }
    public int MdUnitMeasurementId { get; set; }
    public int DevolutionQuantity { get; set; }

}



