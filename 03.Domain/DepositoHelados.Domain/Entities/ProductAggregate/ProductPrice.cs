namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Entities.MasterAggregate;

public class ProductPrice: BaseAudit<Guid>
{
    public virtual Guid ProductId { get; private set; } 
    public virtual int MdUnitMeasurementId { get; private set; } 
    public virtual decimal PurchasePrice { get; private set; }
    public virtual decimal SalePrice { get; private set; }
    public virtual decimal PublicPrice  { get; private set; }
    public virtual decimal EmployeePrice  { get; private set; }
    public virtual decimal OtherPriceOne { get; private set; }
    public virtual decimal OtherPriceTwo { get; private set; }

    public virtual Product Product { get; set; }
    public virtual MasterDetail MdUnitMeasurement { get; set; }

    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetMdUnitMeasurementId(int mdUnitMeasurementId) => MdUnitMeasurementId = mdUnitMeasurementId;
    public void SetPurchasePrice(int purchasePrice) => PurchasePrice = purchasePrice;
    public void SetSalePrice(int salePrice) => SalePrice = salePrice;
    public void SetPublicPrice(int publicPrice) => PublicPrice = publicPrice;
    public void SetEmployeePrice(int employeePrice) => EmployeePrice = employeePrice;
    public void SetOtherPriceOne(int otherPriceOne) => OtherPriceOne = otherPriceOne;
    public void SetOtherPriceTwo(int otherPriceTwo) => OtherPriceTwo = otherPriceTwo;
}