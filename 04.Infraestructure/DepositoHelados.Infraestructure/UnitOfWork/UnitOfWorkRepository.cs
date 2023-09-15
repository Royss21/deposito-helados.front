using DepositoHelados.Infraestructure.Repositories;

namespace DepositoHelados.Infraestructure.UnitOfWork;
public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    public ICategoryRepository CategoryRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IEmployeeOrderProductRepository EmployeeOrderProductRepository { get; }
    public IPersonRepository PersonRepository { get; }
    public IMasterRepository MasterRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public UnitOfWorkRepository(ApplicationDbContext context)
	{
        CategoryRepository = new CategoryRepository(context);
        ProductRepository = new ProductRepository(context);
        PersonRepository = new PersonRepository(context);
        RoleRepository = new RoleRepository(context);
        MasterRepository = new MasterRepository(context);
        OrderRepository = new OrderRepository(context);
        EmployeeOrderProductRepository = new EmployeeOrderProductRepository(context);
    }
}