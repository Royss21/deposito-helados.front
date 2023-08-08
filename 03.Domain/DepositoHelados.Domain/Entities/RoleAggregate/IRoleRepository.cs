namespace DepositoHelados.Domain.Entities.RoleAggregate;

public interface IRoleRepository :
    IAggregateRoot,
    ICreateRepository<Role>,
    IUpdateRepository<Role>,
    IReadRepository<Role>,
    IRemoveRepository<Role>,
    IValidateRepository<Role>
{

}

