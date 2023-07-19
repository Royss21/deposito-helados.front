using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Domain.Entities.UserAggregate;

public class User : BaseAudit<Guid>, IAggregateRoot
{
    private readonly List<UserRole> _userRoles = new();

    public virtual int PersonRoleId { get; private set; }
    public virtual string UserName { get; private set; } = string.Empty;
    public virtual string Password { get; private set; } = string.Empty;
    public virtual int HashType { get; private set; }
    public virtual Guid CompanyId { get; private set; }

    public virtual Company Company { get; set; }
    public IEnumerable<UserRole> UserRoles => _userRoles.AsReadOnly();

    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetUserName(string userName) => UserName = userName;
    public void SetPassword(string password) => Password = password;
    public void SetHashType(int hashType) => HashType = hashType;
}