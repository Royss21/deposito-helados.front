namespace DepositoHelados.Domain.Entities.UserAggregate;

public class UserRole : BaseAudit<int>
{
    public virtual int UserId { get; private set; }
    public virtual int RoleId { get; private set; }
    public virtual int CampusId { get; private set; }

    public void SetUserId(int userId) => UserId = userId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetCampusId(int campusId) => CampusId = campusId;
}