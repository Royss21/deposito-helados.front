namespace DepositoHelados.Domain.Entities.UserAggregate;

public class Menu : BaseAudit<Guid>, IAggregateRoot
{
    private readonly List<MenuRole> _menuRoles = new();

    public virtual string Icon  { get; private set; } = string.Empty;
    public virtual string Name  { get; private set; } = string.Empty;
    public virtual string Url  { get; private set; } = string.Empty;
    public virtual int Sort  { get; private set; }

    public IEnumerable<MenuRole> MenuRoles => _menuRoles.AsReadOnly();
    
    public void SetIcon(string icon) => Icon = icon;
    public void SetName(string name) => Name = name;
    public void SetUrl(string url) => Url = url;
    public void SetSort(int sort) => Sort = sort;
}