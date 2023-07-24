

using DepositoHelados.Domain.Entities.RoleAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class RoleConfig : BaseEntityTypeConfig<Role, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Code)
            .HasMaxLength(12)
            .IsRequired();

        builder.Property(p => p.CompanyId)
            .IsRequired();

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Roles)
            .HasForeignKey( p => p.CompanyId);

        builder.HasMany(p => p.MenuRoles)
            .WithOne(p => p.Role)
            .HasForeignKey( p => p.RoleId);

        builder.HasMany(p => p.PersonRoles)
            .WithOne(p => p.Role)
            .HasForeignKey( p => p.RoleId);
    }  
}
