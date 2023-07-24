


using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class EmployeeProductOrderConfig : BaseEntityTypeConfig<EmployeeProductOrder, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<EmployeeProductOrder> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.PersonRoleId)
            .IsRequired();

        builder.Property(p => p.DateProductOrder)
            .IsRequired();
            
        builder.HasMany(p => p.EmployeeProductOrderDetails)
            .WithOne(p => p.EmployeeProductOrder)
            .HasForeignKey( p => p.EmployeeProductOrderId);
            
        builder.HasOne(p => p.PersonRole)
            .WithMany(p => p.EmployeeProductsOrders)
            .HasForeignKey( p => p.PersonRoleId);

        builder.HasOne(p => p.PersonRole)
            .WithMany(p => p.EmployeeProductsOrders)
            .HasForeignKey( p => p.PersonRoleId);

    }  
}
