using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Domain.Base;

public abstract class BaseEntity<TId>
{
    public virtual TId Id { get; protected set; }
}

public abstract class BaseAudit<TId> 
    : BaseEntity<TId>, IBaseAudit
{
    public string CreateUser { get; set; } = string.Empty;
    public DateTime CreateDate { get ; set ; }
    public string ModifyUser { get ; set ; } = string.Empty;
    public DateTime? ModifyDate { get ; set ; }
    public string DeleteUser { get ; set ; } = string.Empty;
    public DateTime? DeleteDate { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public bool IsActive { get ; set ; }
}

public abstract class BaseAuditCompany<TId> 
    : BaseAudit<TId>, IBaseCompany
{
    public virtual Guid CompanyId { get ; set ; }
    public virtual Company Company { get; set; }
}

