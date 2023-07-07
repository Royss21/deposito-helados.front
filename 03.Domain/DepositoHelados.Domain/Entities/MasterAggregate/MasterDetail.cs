using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;

namespace DepositoHelados.Domain.Entities.MasterAggregate;

public class MasterDetail: BaseAudit<int>
{
    private readonly List<Archive> _archives = new();
    private readonly List<Company> _companies = new();
    private readonly List<EmployeeProductOrderDetail> _employeeProductOrderDetails = new();

    public virtual Guid MasterId { get; private set; }
    public virtual string Code { get; private set; } = string.Empty;
    public virtual string Name { get; private set; } = string.Empty;
    public virtual string Description { get; private set; } = string.Empty;
    public virtual string AdditionalOne { get; private set; } = string.Empty;
    public virtual string AdditionalSecond { get; private set; } = string.Empty;
    public virtual int Sort { get; private set; }

    public virtual Master Master { get; private set; }
    public IEnumerable<Archive> Archives => _archives.AsReadOnly();
    public IEnumerable<Company> Companies => _companies.AsReadOnly();
    public IEnumerable<EmployeeProductOrderDetail> EmployeeProductOrderDetails => _employeeProductOrderDetails.AsReadOnly();

    public void SetSort(int sort) => Sort = sort;
    public void SetName(string name) => Name = name;
    public void SetCode(string code) => Code = code;
    public void SetDescription(string description) => Description = description;
    public void SetAdditionalOne(string additionalOne) => AdditionalOne = additionalOne;
    public void SetAdditionalSecond(string additionalSecond) => AdditionalSecond = additionalSecond;
}