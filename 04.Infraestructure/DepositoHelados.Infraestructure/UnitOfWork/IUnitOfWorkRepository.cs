

namespace DepositoHelados.Infraestructure.UnitOfWork;

public interface IUnitOfWorkRepository
{
    IProductRepository ProductRepository { get; }
    IPersonRepository PersonRepository { get; }
    IRoleRepository RoleRepository { get; }
    IOrderRepository OrderRepository { get; }
    IMasterRepository MasterRepository { get; }
    IEmployeeOrderProductRepository EmployeeOrderProductRepository { get; }
}