namespace DepositoHelados.Domain.Entities.ProductAggregate;

using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;

public class ProductFlavor: BaseAudit<int>
{
    public virtual int MdFlavorId { get; private set; } 
    public virtual Guid ProductId { get; private set; } 
    public virtual Guid? ArchiveId { get; private set; }
    public virtual int Sort { get; private set; }

    public virtual MasterDetail MdFlavor { get; set; }
    public virtual Product Product { get; set; }
    public virtual Archive Archive { get; set; }

    public void SetArchiveId(Guid archiveId) => ArchiveId = archiveId;
    public void SetProductId(Guid productId) => ProductId = productId;
    public void SetSort(int sort) => Sort = sort;
    public void SetMdFlavorId(int mdFlavorId) => MdFlavorId = mdFlavorId;
}