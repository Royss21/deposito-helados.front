namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public interface IEmployeeProductOrderRepository :
        IAggregateRoot,
        ICreateRepository<EmployeeProductOrder>,
        IUpdateRepository<EmployeeProductOrder>,
        IReadRepository<EmployeeProductOrder>,
        IRemoveRepository<EmployeeProductOrder>,
        IValidateRepository<EmployeeProductOrder>
{
   
}