using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class PersonRole : BaseAuditCampus<int>
{
    private readonly List<Order> _orders = new();
    private readonly List<AmountAccount> _amountAcounts = new();

    public virtual Guid PersonId  { get; private set; }
    public virtual int RoleId   { get; private set; }
    public virtual string UniqueCode   { get; private set; } = string.Empty;

    public virtual Person Person  { get; private set; }
    public virtual Role Role  { get; private set; }

    public IEnumerable<AmountAccount> AmountAcounts => _amountAcounts.AsReadOnly();
    public IEnumerable<Order> Orders => _orders.AsReadOnly();

    public void SetPersonId(Guid personId) => PersonId = personId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetUniqueCode(string uniqueCode) => UniqueCode = uniqueCode;
}