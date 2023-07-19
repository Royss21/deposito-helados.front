

using DepositoHelados.Domain.Entities.OrderAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class OrderConfig : BaseEntityTypeConfig<Order, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.PersonRoleId)
                .IsRequired();

        builder.Property(p => p.MdOrderTypeId)
            .IsRequired();

        builder.Property(p => p.Code)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(p => p.MdStatusId)
            .IsRequired();

        builder.HasOne(p  => p.PersonRole)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.PersonRoleId);

        builder.HasOne(p => p.MdOrderType)
            .WithMany(p => p.OrderOrderTypes)
            .HasForeignKey( p => p.MdOrderTypeId);

        builder.HasOne(p => p.Campus)
            .WithMany(p => p.Orders)
            .HasForeignKey( p => p.CampusId);

        builder.HasOne(p => p.MdStatus)
            .WithMany(p => p.OrderStatus)
            .HasForeignKey( p => p.MdStatusId);
    }  
}
