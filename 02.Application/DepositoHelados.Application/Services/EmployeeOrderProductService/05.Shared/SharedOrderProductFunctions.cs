using DepositoHelados.Application.Services.EmployeeOrderProductService._01.Shared;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService._05.Shared;

internal static class SharedOrderProductFunctions
{

    public static Action<List<Product>, OrderProductDetailShared, int> ValidateExistingProduct = (existingProducts, item, position) =>
    {
        if (!existingProducts.Any(pe => pe.Id.Equals(item.ProductId)))
            throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_NOT_EXISTS.ReplaceArgs($"{position}"));

        if (existingProducts.Any(pe => pe.Id.Equals(item.ProductId) && !pe.IsActive))
            throw new EmployeeOrderProductException(Constants.Messages.PRODUCT_INACTIVE.ReplaceArgs($"{position}"));
    };
}


