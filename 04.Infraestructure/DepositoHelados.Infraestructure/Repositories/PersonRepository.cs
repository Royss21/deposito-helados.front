using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Infraestructure.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext context) : base(context)
    {}
}

