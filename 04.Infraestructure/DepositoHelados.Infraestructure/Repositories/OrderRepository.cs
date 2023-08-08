namespace DepositoHelados.Infraestructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context= context;
    }

    public virtual void RemoveOrderDetailItem(OrderDetail t)
    {
        _context.OrderDetail.Remove(t);
    }
}

