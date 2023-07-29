

using DepositoHelados.Domain.Entities.CategoryAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class CategoryConfig : BaseEntityTypeConfig<Category, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Icon)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.HasOne(p  => p.CategoryParent)
            .WithMany()
            .HasForeignKey(p => p.CategoryParentId);

        builder.HasOne(p  => p.Company)
            .WithMany(p => p.Categories)
            .HasForeignKey(p => p.CompanyId);

        builder.HasMany(p => p.ProductCategories)
            .WithOne(p => p.Category)
            .HasForeignKey( p => p.CategoryId);
    }  
}
