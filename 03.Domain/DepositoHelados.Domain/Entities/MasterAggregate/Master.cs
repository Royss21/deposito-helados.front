namespace DepositoHelados.Domain.Entities.MasterAggregate;

public class Master: BaseAuditCompany<Guid>, IAggregateRoot
{
    //public Master(Guid id, string code, string name, string description)
    //{
    //    Id= id;
    //    Code= code;
    //    Name= name;
    //    Description= description;
    //}


    private readonly List<MasterDetail> _masterDetails = new();
    
    public virtual string Code { get; private set; } = string.Empty;
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;

    public IEnumerable<MasterDetail> MasterDetails => _masterDetails.AsReadOnly();

    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
    public void SetDescription(string description) => Description = description;
    public void SetCompanyId(Guid companyId) => CompanyId = companyId;
}