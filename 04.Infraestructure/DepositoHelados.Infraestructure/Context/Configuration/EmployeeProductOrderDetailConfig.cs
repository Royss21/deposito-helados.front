


using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class EmployeeProductOrderDetailConfig : BaseEntityTypeConfig<EmployeeProductOrderDetail, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<EmployeeProductOrderDetail> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.EmployeeProductOrderId)
            .IsRequired();

        builder.Property(p => p.ProductId)
            .IsRequired();

        builder.Property(p => p.MdUnitMeasurementId)
            .IsRequired();

        builder.Property(p => p.Quantity)
            .IsRequired();
            
        builder.HasOne(p => p.EmployeeProductOrder)
            .WithMany(p => p.EmployeeProductOrderDetails)
            .HasForeignKey( p => p.EmployeeProductOrderId);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.EmployeeProductOrderDetails)
            .HasForeignKey( p => p.ProductId);

        builder.HasOne(p => p.MdUnitMeasurement)
            .WithMany(p => p.EmployeeProductOrderDetails)
            .HasForeignKey( p => p.MdUnitMeasurementId);
    }  
}
