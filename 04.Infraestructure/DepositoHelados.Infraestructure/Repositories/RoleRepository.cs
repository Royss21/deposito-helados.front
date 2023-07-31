using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Infraestructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {}

}

