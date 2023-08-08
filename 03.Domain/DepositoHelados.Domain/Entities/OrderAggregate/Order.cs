using DepositoHelados.Domain.Commons;
using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Domain.Entities.OrderAggregate;

public class Order : BaseAudit<Guid>, IAggregateRoot, IBaseCampus
{
    public Order(int personRoleId)
    {
        PersonRoleId = personRoleId;
    }


    private readonly List<OrderAdvanceAmount> _orderAdvanceAmounts = new();
    private readonly List<OrderDetail> _orderDetails = new();
    private readonly List<PersonAmountAccount> _personAmountAccounts = new();
    private readonly List<EmployeeOrderProduct> _employeeOrderProducts = new();
    private readonly List<OrderTracking> _orderTrackings = new();

    public virtual int PersonRoleId { get; private set; }
    public virtual int MdOrderTypeId  { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual int MdStatusId { get; private set; }
    public virtual int CampusId { get ; set ; }
    public virtual decimal AmountReceived { get; set; }

    public virtual PersonRole PersonRole { get; set; }
    public virtual MasterDetail MdOrderType { get; set; }
    public virtual MasterDetail MdStatus { get; set; }
    public virtual Campus Campus { get ; set ; }

    public IEnumerable<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();
    public IEnumerable<OrderAdvanceAmount> OrderAdvanceAmounts => _orderAdvanceAmounts.AsReadOnly();
    public IEnumerable<PersonAmountAccount> PersonAmountAccounts => _personAmountAccounts.AsReadOnly();
    public IEnumerable<EmployeeOrderProduct> EmployeeOrderProducts => _employeeOrderProducts.AsReadOnly();
    public IEnumerable<OrderTracking> OrderTrackings => _orderTrackings.AsReadOnly();




    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetMdOrderTypeId(int mdOrderTypeId) => MdOrderTypeId = mdOrderTypeId;
    public void SetCode(string code) => Code = code;
    public void SetCampusId(int campusId) => CampusId = campusId;
    public void SetAmountReceived(decimal amountReceived) => AmountReceived = amountReceived;
    public void SetMdStatusId(int mdStatusId) => MdStatusId = mdStatusId;




    public void AddTrackingStatus(OrderTracking tracking)
    {
        _orderTrackings.Add(tracking);
    }
    public void AddAdvanceAmount(OrderAdvanceAmount amount)
    {
        _orderAdvanceAmounts.Add(amount);
    }

    public decimal GetAmountTotalEmployee()
    {
        return _orderDetails.Any() ? _orderDetails.Sum(s => s.GetSubTotalAmountEmployee()) : 0;
    }

    public decimal GetAmountTotalCustomer()
    {
        return _orderDetails.Any() ? _orderDetails.Sum(s => s.GetSubTotalAmountCustomer()) : 0;
    }

    public void AddOrUpdateProductItem(OrderDetail orderItem)
    {
        var productItem = _orderDetails
             .FirstOrDefault(f => f.ProductId.Equals(orderItem.ProductId) && f.MdUnitMeasurementId == orderItem.MdUnitMeasurementId);

        if (productItem is null)
            _orderDetails.Add(orderItem);
        else
            productItem.SetTotalQuantity(orderItem.TotalQuantity);
    }

    public bool AunFaltaPagar(string roleCode)
    {
        return this.AmountReceived < (roleCode.Contains(Constants.Codes.ROLE_EMPLOYEE) ? this.GetAmountTotalEmployee() : this.GetAmountTotalCustomer());
    }

    public void AssignProductOrders(List<EmployeeOrderProduct> productOrders)
    {
        _employeeOrderProducts.AddRange(productOrders);
    }

    public void AssignAmountsAccount(List<PersonAmountAccount> amountAccounts)
    {
        _personAmountAccounts.AddRange(amountAccounts);
    }

    public void ChangeLastStatus()
    {
        if (_orderTrackings is null || !_orderTrackings.Any())
            throw new OrderException(Constants.Messages.ITEMS_NOT_FOUND);

        SetMdStatusId(_orderTrackings.Last().MdStatusId);
    }

}