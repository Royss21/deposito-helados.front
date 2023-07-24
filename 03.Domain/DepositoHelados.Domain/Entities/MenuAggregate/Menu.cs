using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Domain.Entities.MenuAggregate;

public class Menu : BaseAuditCompany<Guid>, IAggregateRoot
{
    private readonly List<MenuRole> _menuRoles = new();

    public virtual string Icon  { get; private set; } = string.Empty;
    public virtual string Name  { get; private set; } = string.Empty;
    public virtual string Url  { get; private set; } = string.Empty;
    public virtual int Sort  { get; private set; }
    public virtual Guid CompanyId { get; private set; }

    public virtual Company Company { get; set; }
    public IEnumerable<MenuRole> MenuRoles => _menuRoles.AsReadOnly();
    
    public void SetIcon(string icon) => Icon = icon;
    public void SetName(string name) => Name = name;
    public void SetUrl(string url) => Url = url;
    public void SetSort(int sort) => Sort = sort;
}