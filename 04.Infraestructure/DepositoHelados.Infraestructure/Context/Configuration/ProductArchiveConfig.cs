

using DepositoHelados.Domain.Entities.ProductAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ProductArchiveConfig : BaseEntityTypeConfig<ProductArchive, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<ProductArchive> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Sort)
                .IsRequired();

        builder.HasOne(p => p.Archive)
            .WithMany(p => p.ProductArchives)
            .HasForeignKey( p => p.ArchiveId);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductArchives)
            .HasForeignKey( p => p.ProductId);
    }  
}
