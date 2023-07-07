namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class PersonRole : BaseAudit<int>
{

    public virtual Guid PersonId  { get; private set; }
    public virtual int RoleId   { get; private set; }
    public virtual string UniqueCode   { get; private set; } = string.Empty;


    public void SetPersonId(Guid personId) => PersonId = personId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetUniqueCode(string uniqueCode) => UniqueCode = uniqueCode;
}