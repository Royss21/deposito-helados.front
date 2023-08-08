using DepositoHelados.Application.Services.EmployeeOrderProductService._05.Shared;
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
        var productsExisting = await SharedFunctions.GetProductsById(request.ProductOrderItems.Select(s => s.ProductId).ToList(), _unitOfWork);

        var orderProduct = new EmployeeOrderProduct(personRole.Id);
        orderProduct.SetCampusId(request.CampusId);
        orderProduct.SetDateProductOrder(DateTime.UtcNow.GetDateTimePeru());

        foreach(var item in request.ProductOrderItems)
        {
            SharedOrderProductFunctions.ValidateExistingProduct(productsExisting, item, request.ProductOrderItems.IndexOf(item) + 1);
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

