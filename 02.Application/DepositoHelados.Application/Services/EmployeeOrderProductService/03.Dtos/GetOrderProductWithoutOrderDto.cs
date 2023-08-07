namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record GetOrderProductWithoutOrderDto
{
    public DateTime DateOrderProduct { get; set; }
    public List<GetOrderProductWithoutOrderDetailDto> ProductOrderItems { get; set; } = new();
}

public record GetOrderProductWithoutOrderDetailDto
{
    public Guid ProductId { get; set; }
    public string Product { get; set; } = string.Empty;
    public string UnitMeasurement { get; set; } = string.Empty;
    public int MdUnitMeasurementId { get; set; }
    public int Quantity { get; set; }
}

