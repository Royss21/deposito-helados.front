

using DepositoHelados.Domain.Entities.ArchiveAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ArchiveConfig : BaseEntityTypeConfig<Archive, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Archive> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(p => p.FileName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.PathName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(p  => p.MdTypeArchive)
            .WithMany(p => p.Archives)
            .HasForeignKey(f => f.MdTypeArchiveId);

        builder.HasOne(p  => p.Company)
            .WithMany(p => p.Archives)
            .HasForeignKey(f => f.CompanyId);

        builder.HasMany(p => p.ProductArchives)
            .WithOne(p => p.Archive)
            .HasForeignKey( p => p.ArchiveId)
            ;

        builder.HasMany(p => p.ProductFlavors)
            .WithOne(p => p.Archive)
            .HasForeignKey( p => p.ArchiveId)
            ;
    }  
}
