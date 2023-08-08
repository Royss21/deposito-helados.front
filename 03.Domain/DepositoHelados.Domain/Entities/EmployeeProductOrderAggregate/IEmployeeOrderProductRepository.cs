namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public interface IEmployeeOrderProductRepository :
        IAggregateRoot,
        ICreateRepository<EmployeeOrderProduct>,
        IUpdateRepository<EmployeeOrderProduct>,
        IReadRepository<EmployeeOrderProduct>,
        IRemoveRepository<EmployeeOrderProduct>,
        IValidateRepository<EmployeeOrderProduct>
{
    void RemoveOrderProductItem(EmployeeOrderProductDetail t);
}