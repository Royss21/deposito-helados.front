using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.CategoryAggregate;

public class Category: BaseAuditCompany<int>, IAggregateRoot
{
    private readonly List<ProductCategory> _productCategories = new();
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;
    public virtual string Icon { get; private set; } = string.Empty;
    public virtual int Sort { get; private set; }
    public virtual int? CategoryParentId { get; private set; }


    public virtual Category? CategoryParent { get; private set; }
    public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();


    public void SetCategoryId(int categoryParentId) => CategoryParentId = categoryParentId;
    public void SetName(string name) => Name = name;
    public void SetIcon(string icon) => Name = icon;
    public void SetDescription(string description) => Description = description;
    public void SetSort(int sort) => Sort = sort;
}