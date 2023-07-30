
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;
using DepositoHelados.Infraestructure.Repositories;

namespace DepositoHelados.Infraestructure.UnitOfWork;
public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    public IRoleRepository RoleRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IEmployeeOrderProductRepository EmployeeOrderProductRepository { get; }
    public IPersonRepository PersonRepository { get; }

    public UnitOfWorkRepository(ApplicationDbContext context)
	{
        ProductRepository = new ProductRepository(context);
        PersonRepository = new PersonRepository(context);
        RoleRepository = new RoleRepository(context);
        EmployeeOrderProductRepository = new EmployeeOrderProductRepository(context);
    }
}