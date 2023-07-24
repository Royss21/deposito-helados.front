using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CategoryAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.MenuAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Domain.Entities.CompanyAggregate;

public class Company : BaseAudit<Guid>, IAggregateRoot
{
    private readonly List<Campus> _campus = new();
    private readonly List<Role> _roles = new();
    private readonly List<User> _users = new();
    private readonly List<Menu> _menus = new();
    private readonly List<Person> _persons = new();
    private readonly List<Archive> _archives = new();
    private readonly List<Master> _masters = new();
    private readonly List<Category> _categories = new();
    private readonly List<Product> _products = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string BusinessName  { get; private set; } = string.Empty;
    public virtual string Ruc  { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;
    public virtual Guid ArchiveId  { get; private set; }


    public virtual Archive Archive { get; private set; }
    public IEnumerable<Master> Masters => _masters.AsReadOnly();
    public IEnumerable<Archive> Archives => _archives.AsReadOnly();
    public IEnumerable<Campus> Campus => _campus.AsReadOnly();
    public IEnumerable<Role> Roles => _roles.AsReadOnly();
    public IEnumerable<Category> Categories => _categories.AsReadOnly();
    public IEnumerable<User> Users => _users.AsReadOnly();
    public IEnumerable<Menu> Menus => _menus.AsReadOnly();
    public IEnumerable<Person> Persons => _persons.AsReadOnly();
    public virtual IEnumerable<Product> Products => _products.AsReadOnly();
   

    public void SetName(string name) => Name = name;
    public void SetBusinessName(string businessName) => BusinessName = businessName;
    public void SetRuc(string ruc) => Ruc = ruc;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
}