

using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class UserConfig : BaseEntityTypeConfig<User, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.UserName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Password)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.HashType)
            .IsRequired();

        builder.Property(p => p.PersonRoleId)
            .IsRequired();

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Users)
            .HasForeignKey( p => p.CompanyId);

        builder.HasMany(p => p.UserRoles)
            .WithOne(p => p.User)
            .HasForeignKey( p => p.UserId)
            ;
    }  
}
