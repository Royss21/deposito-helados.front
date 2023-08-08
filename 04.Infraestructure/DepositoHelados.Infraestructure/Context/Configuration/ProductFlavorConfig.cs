

using DepositoHelados.Domain.Entities.ProductAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ProductFlavorConfig : BaseEntityTypeConfig<ProductFlavor, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<ProductFlavor> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.MdFlavorId)
                .IsRequired();

        builder.Property(p => p.ProductId)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.Property(p => p.ArchiveId)
            .IsRequired(false);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductFlavors)
            .HasForeignKey( p => p.ProductId);

        builder.HasOne(p => p.Archive)
            .WithMany(p => p.ProductFlavors)
            .HasForeignKey( p => p.ArchiveId);

        builder.HasOne(p => p.MdFlavor)
            .WithMany(p => p.ProductFlavors)
            .HasForeignKey( p => p.MdFlavorId);
    }  
}
