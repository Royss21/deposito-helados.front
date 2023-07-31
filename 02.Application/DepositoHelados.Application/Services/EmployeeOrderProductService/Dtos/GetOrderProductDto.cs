namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record GetOrderProductDto
{
    public DateTime DateOrderProduct { get; set; }
    public List<GetOrderProductDetailDto> ProductOrderItems { get; set; } = new();
}

public record GetOrderProductDetailDto : OrderProductDetailDto
{
    public string Product { get; set; } = string.Empty;
    public string UnitMeasurement { get; set; } = string.Empty;
}

