
namespace DepositoHelados.Domain.Entities.CompanyAggregate;

using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CategoryAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MenuAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;

public class Campus : BaseAudit<int>
{
    private readonly List<Archive> _archives = new();
    private readonly List<Category> _categories = new();
    private readonly List<EmployeeProductOrder> _employeeProductOrders = new();
    private readonly List<Order> _orders = new();
    private readonly List<PersonRole> _personRoles = new();
    private readonly List<Product> _products = new();
    private readonly List<UserRole> _userRoles = new();
    private readonly List<MenuRole> _menuRoles = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;
    public virtual Guid CompanyId  { get; private set; }
    public virtual Company Company { get; private set; }

    public virtual IEnumerable<Archive> Archives => _archives.AsReadOnly();
    public virtual IEnumerable<Category> Categories => _categories.AsReadOnly();
    public virtual IEnumerable<EmployeeProductOrder> EmployeeProductOrders => _employeeProductOrders.AsReadOnly();
    public virtual IEnumerable<Order> Orders => _orders.AsReadOnly();
    public virtual IEnumerable<PersonRole> PersonRoles => this._personRoles.AsReadOnly();
    public virtual IEnumerable<Product> Products => _products.AsReadOnly();
    public virtual IEnumerable<MenuRole> MenuRoles => _menuRoles.AsReadOnly();
    public virtual IEnumerable<UserRole> UserRoles => _userRoles.AsReadOnly();

    public void SetName(string name) => Name = name;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetCompanyId(Guid companyId) => CompanyId = companyId;
}