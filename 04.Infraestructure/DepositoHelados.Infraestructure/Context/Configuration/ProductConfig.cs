

using DepositoHelados.Domain.Entities.ProductAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ProductConfig : BaseEntityTypeConfig<Product, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.MdBrandId)
                .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Products)
            .HasForeignKey( p => p.CompanyId);

        builder.HasOne(p => p.MdBrand)
            .WithMany(p => p.Products)
            .HasForeignKey( p => p.MdBrandId);

        builder.HasMany(p => p.ProductArchives)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;

        builder.HasMany(p => p.OrderDetails)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;

        builder.HasMany(p => p.ProductCategories)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;

        builder.HasMany(p => p.ProductFlavors)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;

        builder.HasMany(p => p.ProductPrices)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;

        builder.HasMany(p => p.EmployeeProductOrderDetails)
            .WithOne(p => p.Product)
            .HasForeignKey( p => p.ProductId)
            ;
    }  
}
