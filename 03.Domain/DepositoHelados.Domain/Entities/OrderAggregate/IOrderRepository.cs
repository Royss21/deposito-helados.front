namespace DepositoHelados.Domain.Entities.OrderAggregate;

public interface IOrderRepository :
        IAggregateRoot,
        ICreateRepository<Order>,
        IUpdateRepository<Order>,
        IReadRepository<Order>,
        IRemoveRepository<Order>,
        IValidateRepository<Order>
{
    void RemoveOrderDetailItem(OrderDetail t);
}