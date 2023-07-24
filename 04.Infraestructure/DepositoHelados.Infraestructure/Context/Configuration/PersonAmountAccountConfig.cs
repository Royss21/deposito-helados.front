

using DepositoHelados.Domain.Entities.PersonAggregate;


namespace DepositoHelados.Infraestructure.Context.Configuration;

public class PersonAmountAccountConfig : BaseEntityTypeConfig<PersonAmountAccount, int>
{
    public override void ConfigureEntity(EntityTypeBuilder<PersonAmountAccount> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.PersonRoleId)
                .IsRequired();

        builder.Property(p => p.Amount)
            .IsRequired();

        builder.Property(p => p.CancellationDate)
            .IsRequired(false);

        builder.Property(p => p.OrderId)
            .IsRequired(false);

        builder.Property(p => p.MdStatusId)
            .IsRequired();

        builder.HasOne(p => p.PersonRole)
            .WithMany(p => p.PersonAmountAccounts)
            .HasForeignKey( p => p.PersonRoleId);

        builder.HasOne(p => p.Order)
            .WithMany(p => p.PersonAmountAccounts)
            .HasForeignKey( p => p.OrderId);

        builder.HasOne(p => p.MdStatus)
           .WithMany(p => p.PersonAmountAcounts)
           .HasForeignKey(p => p.MdStatusId);
    }  
}
