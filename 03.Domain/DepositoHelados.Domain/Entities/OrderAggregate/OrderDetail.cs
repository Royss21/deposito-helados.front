using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class OrderDetail : BaseAudit<int>
{
    public OrderDetail(
        Guid productId, 
        int mdUnitMeasurementId, 
        decimal totalQuantity, 
        decimal devolutionQuantity, 
        decimal productPrice, 
        bool isAmountCalculate
    )
    {
        ProductId = productId;
        MdUnitMeasurementId = mdUnitMeasurementId;
        TotalQuantity = totalQuantity;
        DevolutionQuantity = devolutionQuantity;
        ProductPrice = productPrice;
        IsAmountCalculate = isAmountCalculate;
    }

    public virtual Guid OrderId { get; private set; }
    public virtual Guid ProductId { get; private set; }
    public virtual int MdUnitMeasurementId { get; private set; }
    public virtual decimal TotalQuantity { get; private set; }
    public virtual decimal DevolutionQuantity { get; private set; }
    public virtual decimal ProductPrice   { get; private set; }
    public virtual bool IsAmountCalculate { get; private set; }

    public virtual Order Order  { get; private set; }
    public virtual Product Product  { get; private set; }
    public virtual MasterDetail MdUnitMeasurement  { get; private set; }

    public void SetOrderId(Guid orderId) => OrderId = orderId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetMdUnitMeasurementId(int mdUnitMeasurementId) => MdUnitMeasurementId = mdUnitMeasurementId;
    public void SetTotalQuantity(decimal totalQuantity) => TotalQuantity = totalQuantity;
    public void SetDevolutionQuantity(int devolutionQuantity) => DevolutionQuantity = devolutionQuantity;
    public void SetProductPrice(decimal productPrice) => ProductPrice = productPrice;

    public decimal GetSubTotalAmountEmployee() => (IsAmountCalculate ? (TotalQuantity - DevolutionQuantity) : TotalQuantity) * ProductPrice;
    public decimal GetSubTotalAmountCustomer() => TotalQuantity * ProductPrice;
}