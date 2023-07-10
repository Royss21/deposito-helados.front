namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Entities.CategoryAggregate;

public class ProductCategory: BaseAudit<int>
{
    public virtual int CategoryId { get; private set; } 
    public virtual Guid ProductId { get; private set; } 
    public virtual int Sort { get; private set; }

    public virtual Category Category { get; private set; }
    public virtual Product Product { get; private set; }

    public void SetCategoryId(int categoryId) => CategoryId = categoryId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetSort(int sort) => Sort = sort;
}