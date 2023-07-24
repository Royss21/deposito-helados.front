using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class PersonAddress : BaseAudit<int>
{

   public virtual Guid PersonId { get; private set; }
    public virtual int MdPostalCodeId { get; private set; }
    public virtual string Address { get; private set; } = string.Empty;
    public virtual string ReferenceAddress { get; private set; } = string.Empty;

    public virtual MasterDetail MdPostalCode  { get; private set; }
    public virtual Person Person  { get; private set; }

    public void SetPersonId(Guid personId) => PersonId = personId;
    public void SetMdPostalCodeId(int mdPostalCodeId) => MdPostalCodeId = mdPostalCodeId;
    public void SetAddress(string address) => Address = address;
    public void SetReferenceAddress(string referenceAddress) => ReferenceAddress = referenceAddress;

}