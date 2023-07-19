using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Domain.Entities.PersonAggregate;

public class Person : BaseAudit<Guid>, IAggregateRoot
{

    private readonly List<PersonRole> _personRoles = new();
    private readonly List<PersonAddress> _personAddresses= new();

    public virtual string FirstName { get; private set; } = string.Empty;
    public virtual string SecondName  { get; private set; } = string.Empty;
    public virtual string LastName  { get; private set; } = string.Empty;
    public virtual string MiddleName  { get; private set; } = string.Empty;
    public virtual string IdentityDocument  { get; private set; }  = string.Empty;
    public virtual int MdIdentityDocumentTypeId { get; private set; } 
    public virtual string Email  { get; private set; } = string.Empty;
    public virtual string PhoneNumber   { get; private set; } = string.Empty;
     public virtual Guid CompanyId { get; private set; }

    public virtual Company Company { get; set; }
    public virtual MasterDetail MdIdentityDocumentType  { get; private set; }
    public IEnumerable<PersonRole> PersonRoles => _personRoles.AsReadOnly();
    public IEnumerable<PersonAddress> PersonAddresses => _personAddresses.AsReadOnly();

    public void SetFirstName(string name) => FirstName = name;
    public void SetSecondName(string secondName) => SecondName = secondName;
    public void SetLastName(string lastName) => LastName = lastName;
    public void SetMiddleName(string middleName) => MiddleName = middleName;
    public void SetIdentityDocument(string identityDocument) => IdentityDocument = identityDocument;
    public void SetMdIdentityDocumentTypeId(int mdIdentityDocumentTypeId) => MdIdentityDocumentTypeId = mdIdentityDocumentTypeId;
    public void SetEmail(string email) => Email = email;
    public void SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;

}