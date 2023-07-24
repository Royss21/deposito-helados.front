namespace DepositoHelados.Domain.Entities.MasterAggregate;

public class Master: BaseAuditCompany<Guid>, IAggregateRoot
{
    private readonly List<MasterDetail> _masterDetail = new();
    
    public virtual string Code { get; private set; } = string.Empty;
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;

    public IEnumerable<MasterDetail> MasterDetails => _masterDetail.AsReadOnly();

    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
    public void SetDescription(string description) => Description = description;
}