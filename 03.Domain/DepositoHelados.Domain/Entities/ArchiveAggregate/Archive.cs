using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Domain.Entities.ArchiveAggregate;

public class Archive: BaseAuditCampus<Guid>, IAggregateRoot
{
    private readonly List<Campus> _campus = new();
    private readonly List<Company> _companies = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FileName { get; private set; } = string.Empty;
    public virtual string PathName { get; private set; } = string.Empty;
    public virtual int MdTypeArchiveId { get; private set; } 

    public virtual MasterDetail MdTypeArchive { get; private set; }
    public IEnumerable<Campus> Campus => _campus.AsReadOnly();
    public IEnumerable<Company> Companies => _companies.AsReadOnly();


    public void SetName(string name) => Name = name;
    public void SetFileName(string fileName) => FileName = fileName;
    public void SetPathName(string pathName) => PathName = pathName;
    public void SetMdTypeArchiveId(int mdTypeArchiveId) => MdTypeArchiveId = mdTypeArchiveId;
}