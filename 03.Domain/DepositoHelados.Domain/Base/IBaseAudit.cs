using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Domain.Base;

public interface IBaseAudit
{
    string CreateUser { get; set; } 
    DateTime CreateDate { get ; set ; }
    string ModifyUser { get ; set ; } 
    DateTime? ModifyDate { get ; set ; }
    string DeleteUser { get ; set ; } 
    DateTime? DeleteDate { get ; set ; }
    bool IsDeleted { get ; set ; }
    bool IsActive { get ; set ; }
}

public interface IBaseCampus
{
    int CampusId { get; set; }
    Campus Campus { get; set; }
}

public interface IBaseCompany
{
    Guid CompanyId { get; set; }
    Company Company { get; set; }
}