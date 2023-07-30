namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;

public record OrderProductDetailDto 
{
    public Guid ProductId { get; set; }
    public int MdUnitMeasurementId { get; set; }
    public int Quantity { get; set; }
}

