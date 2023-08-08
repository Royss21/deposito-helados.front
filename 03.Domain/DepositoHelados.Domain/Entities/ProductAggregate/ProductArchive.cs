namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Entities.ArchiveAggregate;

public class ProductArchive: BaseAudit<int>
{
    public virtual Guid ArchiveId { get; private set; } 
    public virtual Guid ProductId { get; private set; } 
    public virtual int Sort { get; private set; }

    public virtual Archive Archive { get; set; }
    public virtual Product Product { get; set; }

    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetSort(int sort) => Sort = sort;
}