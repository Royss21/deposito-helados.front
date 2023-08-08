namespace DepositoHelados.Application.Services.EmployeeOrderProductService._01.Shared;

public record OrderProductDetailShared 
{
    public Guid ProductId { get; set; }
    public int MdUnitMeasurementId { get; set; }
    public int Quantity { get; set; }
}

