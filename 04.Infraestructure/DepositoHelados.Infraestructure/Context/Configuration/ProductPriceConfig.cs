

using DepositoHelados.Domain.Entities.ProductAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class ProductPriceConfig : BaseEntityTypeConfig<ProductPrice, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<ProductPrice> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.ProductId)
                .IsRequired();

        builder.Property(p => p.MdUnitMeasurementId)
            .IsRequired();

        builder.Property(p => p.PurchasePrice)
            .IsRequired();

        builder.Property(p => p.SalePrice)
            .IsRequired();

        builder.Property(p => p.PublicPrice)
            .IsRequired();

        builder.Property(p => p.EmployeePrice)
            .IsRequired();

        builder.Property(p => p.OtherPriceOne)
            .IsRequired();

        builder.Property(p => p.OtherPriceTwo)
            .IsRequired();

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductPrices)
            .HasForeignKey( p => p.ProductId);

        builder.HasOne(p => p.MdUnitMeasurement)
            .WithMany(p => p.ProductPrices)
            .HasForeignKey( p => p.MdUnitMeasurementId);
    }  
}
