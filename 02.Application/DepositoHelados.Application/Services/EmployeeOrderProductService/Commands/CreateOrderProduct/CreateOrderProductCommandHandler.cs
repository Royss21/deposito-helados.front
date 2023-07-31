using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Shared;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Commands.CreateOrderProduct;

internal class CreateOrderProductCommandHandler : BaseHandler, IRequestHandler<CreateOrderProductDto, bool>
{
    public CreateOrderProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(CreateOrderProductDto request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork
            .Repository
            .RoleRepository
            .FirstAsync(s => s.Code.Equals(Constants.ROLE_EMPLOYEE));

        var personRole = await SharedFunctions.GetPersonRole(request.PersonId, role.Id, _unitOfWork);

        var orderProduct = new EmployeeOrderProduct(personRole.Id);
        orderProduct.SetCampusId(request.CampusId);
        orderProduct.SetDateProductOrder(DateTime.UtcNow.GetDateTimePeru());

        var productsExisting = await _unitOfWork
            .Repository
            .ProductRepository
            .GetAllAsync(p => request.ProductOrderItems.Select(s => s.ProductId).Contains(p.Id));

        foreach(var item in request.ProductOrderItems)
        {
            if (!productsExisting.Any(pe => pe.Id.Equals(item.ProductId)))
                throw new EmployeeOrderProductException(Constants.PRODUCT_NOT_EXISTS.ReplaceArgs($"{request.ProductOrderItems.IndexOf(item) + 1}"));

            if (productsExisting.Any(pe => pe.Id.Equals(item.ProductId) && !pe.IsActive))
                throw new EmployeeOrderProductException(Constants.PRODUCT_INACTIVE.ReplaceArgs($"{request.ProductOrderItems.IndexOf(item) + 1}"));

            orderProduct.AddOrUpdateProductItem(item.MdUnitMeasurementId, item.Quantity, item.ProductId);
        }

        await _unitOfWork
            .Repository
            .EmployeeOrderProductRepository
            .AddAsync(orderProduct);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

