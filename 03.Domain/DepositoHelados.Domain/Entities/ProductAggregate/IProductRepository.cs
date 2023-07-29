namespace DepositoHelados.Domain.Entities.ProductAggregate
{
    public interface IProductRepository :
        IAggregateRoot,
        ICreateRepository<Product>,
        IUpdateRepository<Product>,
        IReadRepository<Product>,
        IRemoveRepository<Product>,
        IValidateRepository<Product>
    { }
}
