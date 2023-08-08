using DepositoHelados.Application.Services.OrderService._05.Shared;

namespace DepositoHelados.Application.Services.OrderService._03.Dtos
{
    public class UpdateOrderDto : IRequest<bool>
    {
        public Guid Id { get; set; }
        public decimal AmountReceived { get; set; }
        public List<OrderDetailShared> OrderItems { get; set; } = new();
    }
}
