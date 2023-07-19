using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MenuAggregate;

namespace DepositoHelados.Domain.Entities.RoleAggregate;

public class Role : BaseAudit<int>, IAggregateRoot
{
    private readonly List<MenuRole> _menuRoles = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Code { get; private set; } = string.Empty;
    public virtual Guid CompanyId { get; private set; }

    public virtual Company Company { get; set; }
    public IEnumerable<MenuRole> MenuRoles => _menuRoles.AsReadOnly();
    
    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
}