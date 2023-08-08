using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Application.Services.OrderService._05.Shared;

internal static class SharedOrderFunctions
{
    public static Action<List<Product>, OrderDetailShared, int> ValidateExistingProduct = (existingProducts, item, position) =>
    {
        if (!existingProducts.Any(pe => pe.Id.Equals(item.ProductId)))
            throw new OrderException(Constants.Messages.PRODUCT_NOT_EXISTS.ReplaceArgs($"{position}"));

        if (existingProducts.Any(pe => pe.Id.Equals(item.ProductId) && !pe.IsActive))
            throw new OrderException(Constants.Messages.PRODUCT_INACTIVE.ReplaceArgs($"{position}"));
    };

}

