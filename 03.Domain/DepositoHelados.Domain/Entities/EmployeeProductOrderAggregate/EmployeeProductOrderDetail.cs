using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public class EmployeeProductOrderDetail : BaseAudit<int>
{

    public virtual int EmployeeProductOrderId { get; private set; }
    public virtual Guid ProductId { get; private set; }
    public virtual int MdUnitMeasurementId { get; private set; }
    public virtual decimal Quantity { get; private set; }

    public virtual EmployeeProductOrder EmployeeProductOrder { get; private set; }
    public virtual Product Product { get; private set; }
    public virtual MasterDetail MdUnitMeasurement { get; private set; }

    public void SetEmployeeProductOrderId(int employeeProductOrderId) => EmployeeProductOrderId = employeeProductOrderId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetMdUnitMeasurementId(int mdUnitMeasurementId) => MdUnitMeasurementId = mdUnitMeasurementId;
    public void SetQuantity(int quantity) => Quantity = quantity;
}