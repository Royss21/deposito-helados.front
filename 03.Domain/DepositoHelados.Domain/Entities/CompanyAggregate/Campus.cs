using DepositoHelados.Domain.Entities.ArchiveAggregate;

namespace DepositoHelados.Domain.Entities.CompanyAggregate;

public class Campus : BaseAudit<int>
{
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FiscalAddress  { get; private set; } = string.Empty;
    public virtual Guid CompanyId  { get; private set; }
    public virtual Guid? ArchiveId  { get; private set; }

    public virtual Archive? Archive { get; private set; }
    public virtual Company Company { get; private set; }

    public void SetName(string name) => Name = name;
    public void SetCompanyId(Guid companyId) => CompanyId = companyId;
    public void SetFiscalAddress(string fiscalAddress) => FiscalAddress = fiscalAddress;
    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
}