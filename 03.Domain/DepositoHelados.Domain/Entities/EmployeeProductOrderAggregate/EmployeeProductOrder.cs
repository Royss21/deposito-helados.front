using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

public class EmployeeProductOrder : BaseAudit<int>, IAggregateRoot, IBaseCampus
{
    
    private readonly List<EmployeeProductOrderDetail> _employeeProductOrderDetails = new();
    
    public virtual int PersonRoleId  { get; private set; }
    public virtual DateTime DateProductOrder  { get; private set; }
    public virtual int CampusId { get ; set ; }
    
    public virtual Campus Campus { get ; set; }
    public virtual PersonRole PersonRole { get; private set; }
    public IEnumerable<EmployeeProductOrderDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();


    public void SetPersonRoleId(int personRoleId) => PersonRoleId = personRoleId;
    public void SetDateProductOrder(DateTime dateProductOrder) => DateProductOrder = dateProductOrder;
}