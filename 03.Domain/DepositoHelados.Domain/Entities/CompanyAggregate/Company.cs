using DepositoHelados.Domain.Entities.ArchiveAggregate;

namespace DepositoHelados.Domain.Entities.CompanyAggregate;

public class Company : BaseAuditCampus<Guid>, IAggregateRoot
{

    private readonly List<Campus> _campus = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string BusinessName  { get; private set; } = string.Empty;
    public virtual string Ruc  { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;
    public virtual Guid ArchiveId  { get; private set; }

    public virtual Archive Archive { get; private set; }
    public IEnumerable<Campus> Campus => _campus.AsReadOnly();

    public void SetName(string name) => Name = name;
    public void SetBusinessName(string businessName) => BusinessName = businessName;
    public void SetRuc(string ruc) => Ruc = ruc;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
}