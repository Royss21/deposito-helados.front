using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Domain.Entities.ArchiveAggregate;

public class Archive: BaseAuditCampus<Guid>, IAggregateRoot
{
    private readonly List<ProductArchive> _productArchives = new();
    private readonly List<ProductFlavor> _productFlavor = new();

    public virtual string Name { get; private set; } = string.Empty;
    public virtual string FileName { get; private set; } = string.Empty;
    public virtual string PathName { get; private set; } = string.Empty;
    public virtual int MdTypeArchiveId { get; private set; } 

    public virtual MasterDetail MdTypeArchive { get; private set; }
    public IEnumerable<ProductArchive> ProductArchives => _productArchives.AsReadOnly();
    public IEnumerable<ProductFlavor> ProductFlavor => _productFlavor.AsReadOnly();


    public void SetName(string name) => Name = name;
    public void SetFileName(string fileName) => FileName = fileName;
    public void SetPathName(string pathName) => PathName = pathName;
    public void SetMdTypeArchiveId(int mdTypeArchiveId) => MdTypeArchiveId = mdTypeArchiveId;
}