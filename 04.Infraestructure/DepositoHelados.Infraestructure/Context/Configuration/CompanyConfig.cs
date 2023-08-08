


using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class CompanyConfig : BaseEntityTypeConfig<Company, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(p => p.FiscalAddress)
            .HasMaxLength(250)
            .IsRequired();
            
        builder.Property(p => p.BusinessName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Ruc)
            .HasMaxLength(12)
            .IsRequired();

        builder.HasOne(p  => p.Archive)
            .WithMany(p => p.Companies)
            .HasForeignKey(p => p.ArchiveId);

        builder.HasMany(p => p.Campus)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Roles)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Users)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Categories)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Menus)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Persons)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;

        builder.HasMany(p => p.Products)
            .WithOne(p => p.Company)
            .HasForeignKey( p => p.CompanyId)
            ;
    }  
}
