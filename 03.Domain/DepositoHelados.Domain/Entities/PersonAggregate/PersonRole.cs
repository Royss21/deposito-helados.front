using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class PersonRole : BaseAudit<int>, IBaseCampus
{
    private readonly List<Order> _orders = new();
    private readonly List<PersonAmountAccount> _personAmountAccounts = new();
    private readonly List<EmployeeOrderProduct> _employeeProductsOrders = new();

    public virtual Guid PersonId  { get; private set; }
    public virtual int RoleId   { get; private set; }
    public virtual int CampusId { get ; set ; }
    public virtual string UniqueCode   { get; private set; } = string.Empty;

    public virtual Person Person  { get; private set; }
    public virtual Role Role  { get; private set; }
    public virtual Campus Campus { get ; set ; }

    public IEnumerable<PersonAmountAccount> PersonAmountAccounts => _personAmountAccounts.AsReadOnly();
    public IEnumerable<Order> Orders => _orders.AsReadOnly();
    public IEnumerable<EmployeeOrderProduct> EmployeeProductsOrders => _employeeProductsOrders.AsReadOnly();


    public void SetPersonId(Guid personId) => PersonId = personId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetUniqueCode(string uniqueCode) => UniqueCode = uniqueCode;
}