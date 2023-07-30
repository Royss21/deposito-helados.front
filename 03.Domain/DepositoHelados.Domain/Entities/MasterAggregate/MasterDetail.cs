
using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.MasterAggregate;

public class MasterDetail: BaseAudit<int>
{
    public MasterDetail(
            int id,
            string code, 
            string name, 
            string description, 
            string additionalOne,
            string additionalTwo,
            int sort)
    {
        Id = id;
        Code = code;
        Name = name;    
        Description = description;  
        AdditionalOne = additionalOne;
        AdditionalTwo = additionalTwo;
        Sort = sort;
    }

    private readonly List<EmployeeOrderProductDetail> _employeeProductOrderDetails = new();
    private readonly List<Order> _orderOrderTypes = new();
    private readonly List<Order> _orderStatus = new();
    private readonly List<Person> _persons = new();
    private readonly List<Archive> _archives = new();
    private readonly List<Product> _products = new();
    private readonly List<ProductFlavor> _productFlavors = new();
    private readonly List<ProductPrice> _productPrices = new();
    private readonly List<PersonAddress> _personAddresses = new();
    private readonly List<OrderDetail> _orderDetailUnitMeasurements = new();
    private readonly List<PersonAmountAccount> _personAmountAccounts = new();

    public virtual Guid MasterId { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;
    public virtual string AdditionalOne { get; private set; } = string.Empty;
    public virtual string AdditionalTwo { get; private set; } = string.Empty;
    public virtual int Sort { get; private set; }


   public virtual Master Master { get; private set; }
    public IEnumerable<EmployeeOrderProductDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();
    public IEnumerable<Order> OrderOrderTypes => _orderOrderTypes.AsReadOnly();
    public IEnumerable<Order> OrderStatus => _orderStatus.AsReadOnly();
    public IEnumerable<Person> Persons => _persons.AsReadOnly();
    public IEnumerable<Archive> Archives => _archives.AsReadOnly();
    public IEnumerable<Product> Products => _products.AsReadOnly();
    public IEnumerable<ProductPrice> ProductPrices => _productPrices.AsReadOnly();
    public IEnumerable<ProductFlavor> ProductFlavors => _productFlavors.AsReadOnly();
    public IEnumerable<PersonAddress> PersonAddresses => _personAddresses.AsReadOnly();
    public IEnumerable<OrderDetail> OrderDetailUnitMeasurements => _orderDetailUnitMeasurements.AsReadOnly();
    public IEnumerable<PersonAmountAccount> PersonAmountAcounts => _personAmountAccounts.AsReadOnly();


    public void SetMasterId(Guid masterId) => MasterId = masterId;
    public void SetSort(int sort) => Sort = sort;
    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
    public void SetDescription(string description) => Description = description;
    public void SetAdditionalOne(string additionalOne) => AdditionalOne = additionalOne;
    public void SetAdditionalSecond(string additionalSecond) => AdditionalTwo = additionalSecond;
}