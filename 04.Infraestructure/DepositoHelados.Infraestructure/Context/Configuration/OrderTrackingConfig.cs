namespace DepositoHelados.Infraestructure.Context.Configuration;

public class OrderTrackingConfig : BaseEntityTypeConfig<OrderTracking, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<OrderTracking> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.OrderId)
                .IsRequired();

        builder.Property(p => p.MdStatusId)
             .IsRequired();

        builder.HasOne(p  => p.Order)
            .WithMany(p => p.OrderTrackings)
            .HasForeignKey(p => p.OrderId);

        builder.HasOne(p => p.MdStatus)
            .WithMany(p => p.OrderTrackings)
            .HasForeignKey(p => p.MdStatusId);
    }  
}
