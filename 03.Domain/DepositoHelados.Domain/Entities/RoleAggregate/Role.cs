
using DepositoHelados.Domain.Entities.MenuAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Domain.Entities.RoleAggregate;

public class Role : BaseAuditCompany<int>, IAggregateRoot
{
    private readonly List<MenuRole> _menuRoles = new();
    private readonly List<UserRole> _userRoles = new();
    private readonly List<PersonRole> _personRoles = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Code { get; private set; } = string.Empty;
    public IEnumerable<MenuRole> MenuRoles => _menuRoles.AsReadOnly();
    public IEnumerable<UserRole> UserRoles => _userRoles.AsReadOnly();
    public IEnumerable<PersonRole> PersonRoles => _personRoles.AsReadOnly();
    
    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
}