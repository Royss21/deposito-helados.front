

using DepositoHelados.Domain.Entities.UserAggregate;

namespace DepositoHelados.Infraestructure.Context.Configuration;

public class UserTokenConfig : BaseEntityTypeConfig<UserToken, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.UserRoleId)
            .IsRequired();

        builder.Property(p => p.Token)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(p => p.TokenExpiredDate)
            .IsRequired();

        builder.Property(p => p.RefreshToken)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(p => p.UserRole)
            .WithOne(p => p.UserToken);
    }  
}
