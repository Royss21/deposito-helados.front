

using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class UserRoleConfig : BaseEntityTypeConfig<UserRole, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.UserId)
            .IsRequired();

        builder.Property(p => p.RoleId)
            .IsRequired();

        builder.HasOne(p => p.User)
            .WithMany(p => p.UserRoles)
            .HasForeignKey( p => p.UserId);

        builder.HasOne(p => p.Role)
            .WithMany(p => p.UserRoles)
            .HasForeignKey( p => p.RoleId);

        builder.HasOne(p => p.Campus)
            .WithMany(p => p.UserRoles)
            .HasForeignKey( p => p.CampusId);
    }  
}
