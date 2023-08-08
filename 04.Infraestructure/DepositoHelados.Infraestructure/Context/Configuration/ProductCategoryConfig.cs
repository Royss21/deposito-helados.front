

using DepositoHelados.Domain.Entities.ProductAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ProductCategoryConfig : BaseEntityTypeConfig<ProductCategory, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.CategoryId)
                .IsRequired();

        builder.Property(p => p.ProductId)
            .IsRequired();

        builder.Property(p => p.Sort)
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey( p => p.CategoryId);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey( p => p.CategoryId);
    }  
}
