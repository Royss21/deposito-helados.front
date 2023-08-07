namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class OrderAdvanceAmount : BaseAudit<int>
{
    public OrderAdvanceAmount(decimal amount)
    {
        Amount= amount;
    }

    public virtual Guid OrderId { get; private set; }
    public virtual decimal Amount { get; private set; }

    public virtual Order Order { get; set; }   

    public void SetOrderId(Guid orderId) => OrderId = orderId;
    public void SetAmount(decimal amount) => Amount = amount;
}