

using DepositoHelados.Domain.Entities.MenuAggregate;
namespace DepositoHelados.Infraestructure.Context.Configuration;

public class MenuRoleConfig : BaseEntityTypeConfig<MenuRole, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<MenuRole> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.RoleId)
            .IsRequired();

        builder.Property(p => p.MenuId)
            .IsRequired();

        builder.HasOne(p => p.Menu)
            .WithMany(p => p.MenuRoles)
            .HasForeignKey( p => p.MenuId);
            
        builder.HasOne(p => p.Role)
            .WithMany(p => p.MenuRoles)
            .HasForeignKey( p => p.MenuId);

        builder.HasOne(p => p.Campus)
            .WithMany(p => p.MenuRoles)
            .HasForeignKey( p => p.CampusId);
    }  
}
