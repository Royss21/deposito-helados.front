using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Infraestructure.Repositories;

public class EmployeeOrderProductRepository : GenericRepository<EmployeeOrderProduct>, IEmployeeOrderProductRepository
{
    private readonly ApplicationDbContext _context;
    public EmployeeOrderProductRepository(ApplicationDbContext context) : base(context)
    {
        _context= context;
    }

    public virtual void RemoveOrderProductItem(EmployeeOrderProductDetail t)
    {
        _context.EmployeeProductOrderDetail.Remove(t);
    }
}

