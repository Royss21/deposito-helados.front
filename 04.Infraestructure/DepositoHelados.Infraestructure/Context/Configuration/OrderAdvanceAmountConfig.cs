

using DepositoHelados.Domain.Entities.OrderAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class OrderAdvanceAmountConfig : BaseEntityTypeConfig<OrderAdvanceAmount, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<OrderAdvanceAmount> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.OrderId)
                .IsRequired();

        builder.Property(p => p.Amount)
            .IsRequired();

        builder.HasOne(p  => p.Order)
            .WithMany(p => p.OrderAdvanceAmounts)
            .HasForeignKey(p => p.OrderId);
    }  
}
