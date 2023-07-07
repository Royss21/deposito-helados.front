using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Domain.Entities.UserAggregate;

public class MenuRole : BaseAudit<int>
{
    public virtual int RoleId   { get; private set; }
    public virtual Guid MenuId   { get; private set; }

    public virtual Menu Menu { get; set; }
    public virtual Role Role { get; set; }

    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetMenuId(Guid menuId) => MenuId = menuId;
}