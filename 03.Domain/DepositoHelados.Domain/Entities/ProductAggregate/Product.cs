namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Commons.Interfaces;
using DepositoHelados.Domain.Entities.MasterAggregate;

public class Product: BaseAuditCampus<Guid>, IAggregateRoot
{
    public Product(int mdBrandId, string description) 
    {
        this.MdBrandId = mdBrandId;
        this.Description = description;
    }

    private readonly List<ProductArchive> _productArchives = new();
    private readonly List<ProductCategory> _productCategories = new();
    private readonly List<ProductFlavor> _productFlavors = new();
    private readonly List<ProductPrice> _productPrices = new();

    public virtual int MdBrandId { get; private set; } 
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;

    public virtual MasterDetail MdBrand { get; private set; }
    public IEnumerable<ProductArchive> ProductArchives => _productArchives.AsReadOnly();
    public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();
    public IEnumerable<ProductFlavor> ProductFlavors => _productFlavors.AsReadOnly();
    public IEnumerable<ProductPrice> ProductPrices => _productPrices.AsReadOnly();


    public void SetName(string name) => Name = name;
    public void SetDescription(string description) => Description = description;
    public void SetMdBrandId(int mdBrandId) => MdBrandId = mdBrandId;
}