using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Infraestructure.Repositories;

public class EmployeeProductOrderRepository : GenericRepository<EmployeeProductOrder>, IEmployeeProductOrderRepository
{
    public EmployeeProductOrderRepository(ApplicationDbContext context) : base(context)
    {}
}

