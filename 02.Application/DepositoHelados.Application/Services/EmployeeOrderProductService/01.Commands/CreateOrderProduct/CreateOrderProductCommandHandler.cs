using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
using DepositoHelados.Application.Shared;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Commands.CreateOrderProduct;

internal class CreateOrderProductCommandHandler : BaseHandler, IRequestHandler<CreateOrderProductDto, bool>
{
    public CreateOrderProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(CreateOrderProductDto request, CancellationToken cancellationToken)
    {
        var personRole = await SharedFunctions.GetPersonRole(request.PersonId, Constants.Codes.ROLE_EMPLOYEE, _unitOfWork);

        var orderProduct = new EmployeeOrderProduct(personRole.Id);
        orderProduct.SetCampusId(request.CampusId);
        orderProduct.SetDateProductOrder(DateTime.UtcNow.GetDateTimePeru());

        var productsExisting = await SharedFunctions.GetProductsById(request.ProductOrderItems.Select(s => s.ProductId).ToList(), _unitOfWork);

        foreach(var item in request.ProductOrderItems)
        {
            if (!productsExisting.Any(pe => pe.Id.Equals(item.ProductId)))
                throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_NOT_EXISTS.ReplaceArgs($"{request.ProductOrderItems.IndexOf(item) + 1}"));

            if (productsExisting.Any(pe => pe.Id.Equals(item.ProductId) && !pe.IsActive))
                throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_INACTIVE.ReplaceArgs($"{request.ProductOrderItems.IndexOf(item) + 1}"));

            orderProduct.AddOrUpdateProductItem(new EmployeeOrderProductDetail(item.ProductId, item.MdUnitMeasurementId, item.Quantity));
        }

        await _unitOfWork
            .Repository
            .EmployeeOrderProductRepository
            .AddAsync(orderProduct);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

