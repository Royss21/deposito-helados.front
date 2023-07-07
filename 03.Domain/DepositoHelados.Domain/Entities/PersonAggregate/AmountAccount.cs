namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class AmountAccount : BaseAudit<Guid>
{

    public virtual int PersonRoleId { get; private set; }
    public virtual decimal Amount { get; private set; }
    public virtual DateTime? CancellationDate { get; private set; } 
    public virtual Guid? OrderId { get; private set; } 
    public virtual int MdStatusId { get; private set; }


    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetAmount(decimal amount) => Amount = amount;
    public void SetCancellationDate(DateTime? cancellationDate) => CancellationDate = cancellationDate;
    public void SetOrderId(Guid? orderId) => OrderId = orderId;
    public void SetMdStatusId(int mdStatusId) => MdStatusId = mdStatusId;
}