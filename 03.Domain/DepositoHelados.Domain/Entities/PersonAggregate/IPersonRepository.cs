using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Domain.Entities.PersonAggregate;

public interface IPersonRepository :
        IAggregateRoot,
        ICreateRepository<Person>,
        IUpdateRepository<Person>,
        IReadRepository<Person>,
        IRemoveRepository<Person>,
        IValidateRepository<Person>
{

}
