namespace DepositoHelados.Domain.Entities.MasterAggregate;

public interface IMasterRepository :
    IAggregateRoot,
    ICreateRepository<Master>,
    IUpdateRepository<Master>,
    IReadRepository<Master>,
    IRemoveRepository<Master>,
    IValidateRepository<Master>
{

}