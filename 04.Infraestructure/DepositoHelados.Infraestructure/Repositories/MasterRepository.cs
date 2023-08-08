namespace DepositoHelados.Infraestructure.Repositories;

public class MasterRepository : GenericRepository<Master>, IMasterRepository
{
    public MasterRepository(ApplicationDbContext context) : base(context)
    {}

}

