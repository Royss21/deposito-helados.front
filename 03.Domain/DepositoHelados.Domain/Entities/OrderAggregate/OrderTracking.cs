using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class OrderTracking : BaseAudit<int>
{
    public OrderTracking(int mdStatusId)
    {
        MdStatusId= mdStatusId;
    }

    public virtual Guid OrderId { get; private set; }
    public virtual int MdStatusId { get; private set; }

    public virtual Order Order { get; set; }
    public virtual MasterDetail MdStatus { get; set; }
}