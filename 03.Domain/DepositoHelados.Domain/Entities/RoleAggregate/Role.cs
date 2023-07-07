namespace DepositoHelados.Domain.Entities.RoleAggregate;

public class Role : BaseAuditCampus<int>, IAggregateRoot
{
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Code { get; private set; } = string.Empty;

    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
}