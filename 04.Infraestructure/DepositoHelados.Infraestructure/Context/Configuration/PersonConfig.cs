

using DepositoHelados.Domain.Entities.PersonAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class PersonConfig : BaseEntityTypeConfig<Person, Guid>
{
    public override void ConfigureEntity(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

        builder.Property(p => p.SecondName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p  => p.MiddleName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p  => p.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p  => p.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p  => p.IdentityDocument)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p  => p.MdIdentityDocumentTypeId)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(p => p.Company)
            .WithMany(p => p.Persons)
            .HasForeignKey( p => p.CompanyId);

        builder.HasOne(p => p.MdIdentityDocumentType)
            .WithMany(p => p.Persons)
            .HasForeignKey( p => p.MdIdentityDocumentTypeId);

        builder.HasMany(p => p.PersonRoles)
            .WithOne(p => p.Person)
            .HasForeignKey( p => p.PersonId);

        builder.HasMany(p => p.PersonAddresses)
            .WithOne(p => p.Person)
            .HasForeignKey( p => p.PersonId);
    }  
}
