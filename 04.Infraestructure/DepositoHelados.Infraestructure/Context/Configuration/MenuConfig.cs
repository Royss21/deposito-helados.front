

using DepositoHelados.Domain.Entities.MenuAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class MenuConfig : BaseEntityTypeConfig<Menu, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Icon)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Url)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.Property(p => p.CompanyId)
            .IsRequired();

        builder.HasMany(p => p.MenuRoles)
            .WithOne(p => p.Menu)
            .HasForeignKey(p => p.MenuId)
            ;
    }  
}
