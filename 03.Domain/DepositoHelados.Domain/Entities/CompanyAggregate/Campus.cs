using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CategoryAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Domain.Entities.CompanyAggregate;

public class Campus : BaseAudit<int>
{
    private readonly List<Archive> _archives = new();
    private readonly List<Category> _category = new();
    private readonly List<EmployeeProductOrder> _employeeProductOrder = new();
    private readonly List<Order> _order = new();
    private readonly List<Person> _person = new();
    private readonly List<Product> _product = new();
    private readonly List<User> _user = new();
    private readonly List<Role> _role = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;
    public virtual Guid CompanyId  { get; private set; }
    public virtual Guid? ArchiveId  { get; private set; }

    public virtual Archive? Archive { get; private set; }
    public virtual Company Company { get; private set; }

    public IEnumerable<Archive> Archives => _archives.AsReadOnly();
    public IEnumerable<Category> Category => _category.AsReadOnly();
    public IEnumerable<EmployeeProductOrder> EmployeeProductOrder => _employeeProductOrder.AsReadOnly();
    public IEnumerable<Order> Order => _order.AsReadOnly();
    public IEnumerable<Person> Person => _person.AsReadOnly();
    public IEnumerable<Product> Product => _product.AsReadOnly();
    public IEnumerable<User> User => _user.AsReadOnly();
    public IEnumerable<Role> Role => _role.AsReadOnly();

    public void SetName(string name) => Name = name;
    public void SetCompanyId(Guid companyId) => CompanyId = companyId;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
}