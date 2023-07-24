namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Commons.Interfaces;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;

public class Product: BaseAuditCompany<Guid>, IAggregateRoot
{
    private readonly List<ProductArchive> _productArchives = new();
    private readonly List<ProductCategory> _productCategories = new();
    private readonly List<ProductFlavor> _productFlavors = new();
    private readonly List<ProductPrice> _productPrices = new();
    private readonly List<OrderDetail> _orderDetails = new();
    private readonly List<EmployeeProductOrderDetail> _employeeProductOrderDetails = new();

    public virtual int MdBrandId { get; private set; } 
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;

    public virtual MasterDetail MdBrand { get; private set; }
    public IEnumerable<ProductArchive> ProductArchives => _productArchives.AsReadOnly();
    public IEnumerable<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();
    public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();
    public IEnumerable<ProductFlavor> ProductFlavors => _productFlavors.AsReadOnly();
    public IEnumerable<ProductPrice> ProductPrices => _productPrices.AsReadOnly();
    public IEnumerable<EmployeeProductOrderDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();


    public void SetName(string name) => Name = name;
    public void SetDescription(string description) => Description = description;
    public void SetMdBrandId(int mdBrandId) => MdBrandId = mdBrandId;
}