
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Infraestructure.UnitOfWork;

public interface IUnitOfWorkRepository
{
    IProductRepository ProductRepository { get; }
    IPersonRepository PersonRepository { get; }
    IRoleRepository RoleRepository { get; }
    IEmployeeOrderProductRepository EmployeeOrderProductRepository { get; }
}