using DepositoHelados.Application.Services.OrderService._05.Shared;

namespace DepositoHelados.Application.Services.OrderService._03.Dtos
{
    public class CreateOrderDto : IRequest<bool>
    {
        public string OrderTypeCode { get; set; } = string.Empty;
        public string RoleCode { get; set; } = string.Empty;
        public Guid PersonId { get; set; }
        public int CampusId { get; set; }
        public decimal AmountReceived { get; set; }
        public List<int> OrderProductsIds { get; set; } = new();
        public List<int> AmountsAccountIds { get; set; } = new();
        public List<OrderDetailShared> OrderItems { get; set; } = new();
    }
}
