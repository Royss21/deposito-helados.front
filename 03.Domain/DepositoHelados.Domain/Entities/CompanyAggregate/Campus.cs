
namespace DepositoHelados.Domain.Entities.CompanyAggregate;

using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CategoryAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MenuAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;

public class Campus : BaseAuditCompany<int>
{
    private readonly List<EmployeeProductOrder> _employeeProductOrders = new();
    private readonly List<Order> _orders = new();
    private readonly List<PersonRole> _personRoles = new();
    private readonly List<UserRole> _userRoles = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;


    public virtual IEnumerable<EmployeeProductOrder> EmployeeProductOrders => _employeeProductOrders.AsReadOnly();
    public virtual IEnumerable<Order> Orders => _orders.AsReadOnly();
    public virtual IEnumerable<PersonRole> PersonRoles => _personRoles.AsReadOnly();
    public virtual IEnumerable<UserRole> UserRoles => _userRoles.AsReadOnly();
    

    public void SetName(string name) => Name = name;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetCompanyId(Guid companyId) => CompanyId = companyId;
}