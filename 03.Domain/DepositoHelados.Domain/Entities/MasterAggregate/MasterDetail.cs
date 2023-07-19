
using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;

namespace DepositoHelados.Domain.Entities.MasterAggregate;

public class MasterDetail: BaseAudit<int>
{
    private readonly List<EmployeeProductOrderDetail> _employeeProductOrderDetails = new();
    private readonly List<Order> _orderOrderTypes = new();
    private readonly List<Order> _orderStatus = new();
    private readonly List<OrderDetail> _orderDetailUnitMeasurements = new();

    public virtual Guid MasterId { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;
    public virtual string AdditionalOne { get; private set; } = string.Empty;
    public virtual string AdditionalSecond { get; private set; } = string.Empty;
    public virtual int Sort { get; private set; }
    public virtual Guid CompanyId { get; private set; }

    public virtual Company Company { get; set; }
    public virtual Master Master { get; private set; }

    public IEnumerable<EmployeeProductOrderDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();
    public IEnumerable<Order> OrderOrderTypes => _orderOrderTypes.AsReadOnly();
    public IEnumerable<Order> OrderStatus => _orderStatus.AsReadOnly();
    public IEnumerable<OrderDetail> OrderDetailUnitMeasurements => _orderDetailUnitMeasurements.AsReadOnly();

    public void SetSort(int sort) => Sort = sort;
    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
    public void SetDescription(string description) => Description = description;
    public void SetAdditionalOne(string additionalOne) => AdditionalOne = additionalOne;
    public void SetAdditionalSecond(string additionalSecond) => AdditionalSecond = additionalSecond;
}