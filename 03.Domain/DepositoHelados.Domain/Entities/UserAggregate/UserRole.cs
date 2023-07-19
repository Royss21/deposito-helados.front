namespace DepositoHelados.Domain.Entities.UserAggregate;

public class UserRole : BaseAuditCampus<int>
{
    public virtual int UserId { get; private set; }
    public virtual int RoleId { get; private set; }

    public void SetUserId(int userId) => UserId = userId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetCampusId(Guid campusId) => CampusId = campusId;
}