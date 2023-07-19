

using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;
public class MasterDetailConfig : BaseEntityTypeConfig<MasterDetail, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<MasterDetail> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.MasterId)
            .IsRequired();

        builder.Property(p => p.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.AdditionalOne)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.AdditionalSecond)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.HasOne(p => p.Master)
            .WithMany(p => p.MasterDetails)
            .HasForeignKey( p => p.MasterId);

        builder.HasOne(p => p.Company)
            .WithMany(p => p.MasterDetails)
            .HasForeignKey( p => p.CompanyId);

        builder.HasMany(p => p.EmployeeProductOrderDetails)
            .WithOne(p => p.MdUnitMeasurement)
            .HasForeignKey( p => p.MdUnitMeasurementId);
    }  
}
