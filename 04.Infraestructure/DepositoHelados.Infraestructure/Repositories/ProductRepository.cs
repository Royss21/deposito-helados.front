using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Infraestructure.Context;
using DepositoHelados.Infraestructure.Repositories.Base;

namespace DepositoHelados.Infraestructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {}
}

