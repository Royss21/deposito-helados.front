namespace DepositoHelados.Domain.Entities.CategoryAggregate;

public interface ICategoryRepository :
        IAggregateRoot,
        ICreateRepository<Category>,
        IUpdateRepository<Category>,
        IReadRepository<Category>,
        IRemoveRepository<Category>,
        IValidateRepository<Category>
{

}
