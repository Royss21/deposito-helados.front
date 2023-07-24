
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Infraestructure.Context;
using DepositoHelados.Infraestructure.Repositories;

namespace DepositoHelados.Infraestructure.UnitOfWork;
public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    public IProductRepository ProductRepository { get; }

	public UnitOfWorkRepository(ApplicationDbContext context)
	{
        ProductRepository = new ProductRepository(context);
    }
}