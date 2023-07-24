
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Infraestructure.UnitOfWork;

public interface IUnitOfWorkRepository
{
    IProductRepository ProductRepository { get; }
}