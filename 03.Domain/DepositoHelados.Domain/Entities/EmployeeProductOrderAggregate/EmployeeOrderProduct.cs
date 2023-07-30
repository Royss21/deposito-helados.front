using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public class EmployeeOrderProduct : BaseAudit<int>, IAggregateRoot, IBaseCampus
{

    public EmployeeOrderProduct(int personRoleId)
    {
        PersonRoleId = personRoleId;
    }

    private readonly List<EmployeeOrderProductDetail> _employeeProductOrderDetails = new();
    
    public virtual int PersonRoleId  { get; private set; }
    public virtual DateTime DateProductOrder  { get; private set; }
    public virtual int CampusId { get ; set ; }
    
    public virtual Campus Campus { get ; set; }
    public virtual PersonRole PersonRole { get; private set; }
    public IEnumerable<EmployeeOrderProductDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();


    public void SetCampusId(int campusId) => CampusId = campusId;
    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetDateProductOrder(DateTime dateProductOrder) => DateProductOrder = dateProductOrder;

    
    public void AddOrUpdateProductItem(int mdUnitMeasurementId, int quantity, Guid productId)
    {
        var productItem = _employeeProductOrderDetails
             .FirstOrDefault(f => f.ProductId.Equals(productId) && f.MdUnitMeasurementId == mdUnitMeasurementId);

        if (productItem is null)
            _employeeProductOrderDetails.Add(new EmployeeOrderProductDetail(productId, mdUnitMeasurementId, quantity));
        else
            productItem.SetQuantity(quantity);
    }

    public void RemoveProductItem(EmployeeOrderProductDetail productItem)
    {
        _employeeProductOrderDetails.Remove(productItem);
    }
}