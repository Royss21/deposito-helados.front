
using DepositoHelados.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepositoHelados.Infraestructure.Context.Base;
public abstract class BaseEntityTypeConfig<TEntity, TId> 
    : IEntityTypeConfiguration<TEntity> 
    where TEntity : BaseAudit<TId>
{

    public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureEntity(builder);

        builder.Property(p => p.CreateDate)
            .IsRequired();

        builder.Property(p => p.CreateUser)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.ModifyDate)
            .IsRequired(false);

        builder.Property(p => p.ModifyUser)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(p => p.DeleteDate)
            .IsRequired(false);

        builder.Property(p => p.DeleteUser)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false);
    }
}