using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class Order : BaseAudit<Guid>, IAggregateRoot, IBaseCampus
{
    private readonly List<OrderAdvanceAmount> _orderAdvanceAmounts = new();
    private readonly List<OrderDetail> _orderDetails = new();
    private readonly List<PersonAmountAccount> _personAmountAccounts = new();

    public virtual int PersonRoleId { get; private set; }
    public virtual int MdOrderTypeId  { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual int MdStatusId { get; private set; }
    public virtual int CampusId { get ; set ; }

    public virtual PersonRole PersonRole { get; set; }
    public virtual MasterDetail MdOrderType { get; set; }
    public virtual MasterDetail MdStatus { get; set; }
    public virtual Campus Campus { get ; set ; }

    public IEnumerable<OrderAdvanceAmount> OrderAdvanceAmounts => _orderAdvanceAmounts.AsReadOnly();
    public IEnumerable<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();
    public IEnumerable<PersonAmountAccount> PersonAmountAccounts => _personAmountAccounts.AsReadOnly();


    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetMdOrderTypeId(int mdOrderTypeId) => MdOrderTypeId = mdOrderTypeId;
    public void SetCode(string code) => Code = code;
    public void SetMdStatusId(int mdStatusId) => MdStatusId = mdStatusId;
}