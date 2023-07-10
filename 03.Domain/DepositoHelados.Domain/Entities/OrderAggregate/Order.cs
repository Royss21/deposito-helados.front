using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class Order : BaseAuditCampus<Guid>, IAggregateRoot
{
    private readonly List<OrderAdvanceAmount> _orderAdvanceAmount = new();

    public virtual int PersonRoleId { get; private set; }
    public virtual int MdOrderTypeId  { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual int MdStatusId { get; private set; }

    public virtual PersonRole PersonRole { get; set; }
    public virtual MasterDetail MdOrderType { get; set; }
    public virtual MasterDetail MdStatus { get; set; }

    public IEnumerable<OrderAdvanceAmount> OrderAdvanceAmount => _orderAdvanceAmount.AsReadOnly();

    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetMdOrderTypeId(int mdOrderTypeId) => MdOrderTypeId = mdOrderTypeId;
    public void SetCode(string code) => Code = code;
    public void SetMdStatusId(int mdStatusId) => MdStatusId = mdStatusId;
}