

using DepositoHelados.Domain.Entities.MasterAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class MasterConfig : BaseEntityTypeConfig<Master, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Master> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Code)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(400)
            .IsRequired();

        builder.HasMany(p => p.MasterDetails)
            .WithOne(p => p.Master)
            .HasForeignKey( p => p.MasterId);

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Masters)
            .HasForeignKey( p => p.CompanyId);
    }  
}
