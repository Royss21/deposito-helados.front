

using DepositoHelados.Domain.Entities.PersonAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class PersonRoleConfig : BaseEntityTypeConfig<PersonRole, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<PersonRole> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.UniqueCode)
                .HasMaxLength(20)
                .IsRequired();

        builder.HasOne(p => p.Person)
            .WithMany(p => p.PersonRoles)
            .HasForeignKey( p => p.PersonId);

        builder.HasOne(p => p.Role)
            .WithMany(p => p.PersonRoles)
            .HasForeignKey( p => p.RoleId);

        builder.HasOne(p => p.Campus)
            .WithMany(p => p.PersonRoles)
            .HasForeignKey( p => p.CampusId);

        builder.HasMany(p => p.PersonAmountAccounts)
            .WithOne(p => p.PersonRole)
            .HasForeignKey( p => p.PersonRoleId);

        builder.HasMany(p => p.Orders)
            .WithOne(p => p.PersonRole)
            .HasForeignKey( p => p.PersonRoleId);

        builder.HasMany(p => p.EmployeeProductsOrders)
            .WithOne(p => p.PersonRole)
            .HasForeignKey( p => p.PersonRoleId);
    }  
}
