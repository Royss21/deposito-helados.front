


using DepositoHelados.Domain.Entities.CompanyAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class CampusConfig : BaseEntityTypeConfig<Campus, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<Campus> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(p => p.FiscalAddress)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(p  => p.Company)
            .WithMany(p => p.Campus)
            .HasForeignKey(p => p.CompanyId);

        builder.HasMany(p => p.Orders)
            .WithOne(p => p.Campus)
            .HasForeignKey( p => p.CampusId)
            ;

        builder.HasMany(p => p.PersonRoles)
            .WithOne(p => p.Campus)
            .HasForeignKey( p => p.CampusId)
            ;
    }  
}
