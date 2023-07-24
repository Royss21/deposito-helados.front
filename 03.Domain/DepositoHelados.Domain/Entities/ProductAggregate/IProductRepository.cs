namespace DepositoHelados.Domain.Entities.ProductAggregate
{
    public interface IProductRepository :
        ICreateRepository<Product>,
        IUpdateRepository<Product>,
        IReadRepository<Product>,
        IRemoveRepository<Product>,
        IValidateRepository<Product>
    { }
}
