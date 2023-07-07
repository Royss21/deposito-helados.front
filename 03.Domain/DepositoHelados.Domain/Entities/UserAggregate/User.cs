namespace DepositoHelados.Domain.Entities.UserAggregate;

public class User : BaseAuditCampus<Guid>, IAggregateRoot
{
    public virtual int PersonRoleId { get; private set; }
    public virtual string UserName { get; private set; } = string.Empty;
    public virtual string Password { get; private set; } = string.Empty;
    public virtual int HashType { get; private set; }

    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetUserName(string userName) => UserName = userName;
    public void SetPassword(string password) => Password = password;
    public void SetHashType(int hashType) => HashType = hashType;
}