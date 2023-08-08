using DepositoHelados.Application.Services.OrderService._03.Dtos;
using DepositoHelados.Application.Services.OrderService._05.Shared;
using DepositoHelados.Application.Shared;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;

namespace DepositoHelados.Application.Services.OrderService._01.Commands.UpdateOrder
{
    internal class UpdateOrderCommandHandler : BaseHandler, IRequestHandler<UpdateOrderDto, bool>
    {
        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(UpdateOrderDto request, CancellationToken cancellationToken)
        {
            var existingProducts = await SharedFunctions.GetProductsById(request.OrderItems.Select(s => s.ProductId).ToList(), _unitOfWork);
            var order = await _unitOfWork
            .Repository
            .OrderRepository
            .FirstOrDefaultAsync(
                f => f.Id.Equals(request.Id),
                include:
                    i => i.Include(s => s.OrderDetails)
                    .Include(s => s.PersonRole)
            );

            if (order == null)
                throw new EmployeeOrderProductException(Constants.Messages.ORDER_NOT_EXISTS);

            foreach (var product in order.OrderDetails.ToList())
            {
                if (!request.OrderItems.Any(a => a.ProductId == product.ProductId && a.MdUnitMeasurementId == product.MdUnitMeasurementId))
                    _unitOfWork
                        .Repository
                        .OrderRepository
                        .RemoveOrderDetailItem(product);
            }

            foreach (var product in request.OrderItems)
            {
                SharedOrderFunctions.ValidateExistingProduct(existingProducts, product, request.OrderItems.IndexOf(product) + 1);
                order.AddOrUpdateProductItem(new OrderDetail(
                    product.ProductId,
                    product.MdUnitMeasurementId,
                    product.TotalQuantity,
                    product.DevolutionQuantity,
                    product.ProductPrice,
                    product.IsAmountCalculate));
            }

            _unitOfWork
                .Repository
                .OrderRepository
                .Update(order);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
