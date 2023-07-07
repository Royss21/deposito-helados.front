namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class OrderDetail : BaseAudit<int>
{
    public virtual Guid OrderId { get; private set; }
    public virtual Guid ProductId { get; private set; }
    public virtual int MdUnitMeasurementId { get; private set; }
    public virtual decimal TotalQuantity { get; private set; }
    public virtual decimal DevolutionQuantity { get; private set; }
    public virtual decimal ProductPrice   { get; private set; }
    public virtual DateTime OrderDate  { get; private set; }

    public void SetOrderId(Guid orderId) => OrderId = orderId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetMdUnitMeasurementId(int mdUnitMeasurementId) => MdUnitMeasurementId = mdUnitMeasurementId;
    public void SetTotalQuantity(int totalQuantity) => TotalQuantity = totalQuantity;
    public void SetDevolutionQuantity(int devolutionQuantity) => DevolutionQuantity = devolutionQuantity;
    public void SetProductPrice(decimal productPrice) => ProductPrice = productPrice;
    public void SetOrderDate(DateTime orderDate) => OrderDate = orderDate;
}