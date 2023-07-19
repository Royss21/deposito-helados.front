

using DepositoHelados.Domain.Entities.OrderAggregate;
namespace DepositoHelados.Infraestructure.Context.Configuration;

public class OrderDetailConfig : BaseEntityTypeConfig<OrderDetail, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.OrderId)
                .IsRequired();

        builder.Property(p => p.ProductId)
            .IsRequired();

        builder.Property(p => p.MdUnitMeasurementId)
            .IsRequired();

        builder.Property(p => p.TotalQuantity)
            .IsRequired();

        builder.Property(p => p.DevolutionQuantity)
            .IsRequired();

        builder.Property(p => p.ProductPrice)
            .IsRequired();

        builder.Property(p => p.OrderDate)
            .IsRequired();

        builder.HasOne(p  => p.Order)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(p => p.OrderId);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey( p => p.OrderId);

        builder.HasOne(p => p.MdUnitMeasurement)
            .WithMany(p => p.OrderDetailUnitMeasurements)
            .HasForeignKey( p => p.MdUnitMeasurementId);
    }  
}
