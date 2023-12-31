

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

        builder.Property(p => p.AdditionalTwo)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.HasOne(p => p.Master)
            .WithMany(p => p.MasterDetails)
            .HasForeignKey(p => p.MasterId);

        builder.HasMany(p => p.EmployeeProductOrderDetails)
            .WithOne(p => p.MdUnitMeasurement)
            .HasForeignKey( p => p.MdUnitMeasurementId);

        builder.HasMany(p => p.OrderTrackings)
            .WithOne(p => p.MdStatus)
            .HasForeignKey(p => p.MdStatusId);
    }  
}
