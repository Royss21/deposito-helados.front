using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Domain.Entities.MenuAggregate;

public class MenuRole : BaseAuditCampus<int>
{
    public virtual int RoleId   { get; private set; }
    public virtual Guid MenuId   { get; private set; }

    public virtual Menu Menu { get; set; }
    public virtual Role Role { get; set; }
    
    public void SetCampusId(Guid campusId) => CampusId = campusId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetMenuId(Guid menuId) => MenuId = menuId;
}