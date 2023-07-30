using DepositoHelados.Application.Services.EmployeeOrderProductService.Dtos;
using DepositoHelados.Application.Services.EmployeeOrderProductService.Shared;
using DepositoHelados.Domain.Commons.Functions;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Commands.UpdateOrderProduct;

internal class UpdateOrderProductCommand : BaseHandler, IRequestHandler<UpdateOrderProductDto, bool>
{
    public UpdateOrderProductCommand(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(UpdateOrderProductDto request, CancellationToken cancellationToken)
    {
        var orderProduct = await _unitOfWork
            .Repository
            .EmployeeOrderProductRepository
            .FirstOrDefaultAsync(
                f => f.Id == request.Id, 
                include: 
                    i=>i.Include(s => s.EmployeeProductOrderDetails)
                    .Include(s => s.PersonRole)
            );

        if (orderProduct == null)
            throw new EmployeeOrderProductException(Constants.ORDER_PRODUCT_NOT_EXISTS);

        if(orderProduct.PersonRole.PersonId != request.PersonId)
        {
            var personRole = await SharedFunctions.GetPersonRole(request.PersonId, orderProduct.PersonRole.RoleId, _unitOfWork);
            orderProduct.SetPersonRoleId(personRole.Id);
        }

        foreach(var product in orderProduct.EmployeeProductOrderDetails.ToList())
        {
            if(!request.ProductOrderItems.Any(a => a.ProductId == product.ProductId && a.MdUnitMeasurementId == product.MdUnitMeasurementId))
                _unitOfWork
                    .Repository
                    .EmployeeOrderProductRepository
                    .RemoveOrderProductItem(product);
        }

        foreach(var product in request.ProductOrderItems)
        {
            orderProduct.AddOrUpdateProductItem(
                    product.MdUnitMeasurementId, 
                    product.Quantity, 
                    product.ProductId
                );
        }

        _unitOfWork
            .Repository
            .EmployeeOrderProductRepository
            .Update(orderProduct);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

