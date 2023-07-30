using DepositoHelados.Domain.Commons;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public class EmployeeOrderProductDetail : BaseAudit<int>
{
    public EmployeeOrderProductDetail(Guid productId, int mdUnitMeasurementId, int quantity)
    {
        ProductId = productId;
        MdUnitMeasurementId = mdUnitMeasurementId;
        Quantity = (quantity > 0) ? quantity : throw new EmployeeOrderProductException(Constants.QUANTITY_ZERO);
    }

    public virtual int EmployeeProductOrderId { get; private set; }
    public virtual Guid ProductId { get; private set; }
    public virtual int MdUnitMeasurementId { get; private set; }
    public virtual int Quantity { get; private set; }

    public virtual EmployeeOrderProduct EmployeeProductOrder { get; private set; }
    public virtual Product Product { get; private set; }
    public virtual MasterDetail MdUnitMeasurement { get; private set; }

    public void SetEmployeeProductOrderId(int employeeProductOrderId) => EmployeeProductOrderId = employeeProductOrderId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetMdUnitMeasurementId(int mdUnitMeasurementId) => MdUnitMeasurementId = mdUnitMeasurementId;
    public void SetQuantity(int quantity) => Quantity = quantity;

}