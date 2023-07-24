

using DepositoHelados.Domain.Entities.PersonAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class PersonAddressConfig : BaseEntityTypeConfig<PersonAddress, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<PersonAddress> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Address)
                .HasMaxLength(150)
                .IsRequired();

        builder.Property(p => p.ReferenceAddress)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.MdPostalCodeId)
            .IsRequired();

        builder.Property(p  => p.PersonId)
            .IsRequired();

        builder.HasOne(p => p.MdPostalCode)
            .WithMany(p => p.PersonAddresses)
            .HasForeignKey( p => p.MdPostalCodeId);

        builder.HasOne(p => p.Person)
            .WithMany(p => p.PersonAddresses)
            .HasForeignKey( p => p.PersonId);
    }  
}
