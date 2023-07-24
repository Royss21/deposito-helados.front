using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Domain.Entities.UserAggregate;

public class UserRole : BaseAudit<int>, IBaseCampus
{
    public virtual Guid UserId { get; private set; }
    public virtual int RoleId { get; private set; }
    public virtual int CampusId { get ; set ; }

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
    public virtual Campus Campus { get ; set ; }


    public virtual UserToken UserToken { get; set; }

    public void SetUserId(Guid userId) => UserId = userId;
    public void SetRoleId(int roleId) => RoleId = roleId;
    public void SetCampusId(int campusId) => CampusId = campusId;
}