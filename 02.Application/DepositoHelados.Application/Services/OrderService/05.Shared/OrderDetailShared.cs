namespace DepositoHelados.Application.Services.OrderService._05.Shared
{
    public class OrderDetailShared
    {
        public Guid ProductId { get; set; }
        public int MdUnitMeasurementId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal DevolutionQuantity { get; set; }
        public bool IsAmountCalculate { get; set; }
    }
}
