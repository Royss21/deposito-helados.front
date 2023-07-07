namespace DepositoHelados.Domain.Base;

internal interface IBaseAudit
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

internal interface IBaseCampus
{
    Guid CampusId { get; set; }
}