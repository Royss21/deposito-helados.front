using Azure.Core;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Application.Shared;

internal static class SharedFunctions
{

    public static Func<Guid, string, IUnitOfWork, Task<PersonRole>> GetPersonRole = async (personId, roleCode, _unitOfWork) =>
    {
        var personEmployee = await _unitOfWork
                    .Repository
                    .PersonRepository
                    .FirstOrDefaultAsync(f =>
                        f.Id.Equals(personId) &&
                        f.PersonRoles.Select(c => c.Role.Code).Contains(roleCode),
                        include:
                            i => i.Include(s => s.PersonRoles)
                                    .ThenInclude(s => s.Role)        
                        );

        if (personEmployee == null)
            throw new EmployeeOrderProductException(Constants.Messages.VALUE_NULL);

        if (!personEmployee.PersonRoles.Any())
            throw new EmployeeOrderProductException(
                (
                    roleCode.Equals(Constants.Codes.ROLE_EMPLOYEE)
                        ? Constants.Messages.NO_ASSIGN_ROLE_EMPLOYEE
                        : Constants.Messages.NO_ASSIGN_ROLE_CUSTOMER
                ).ReplaceArgs($"{personEmployee.FirstName} {personEmployee.LastName}"));

        return personEmployee
            .PersonRoles
            .First(f => f.Role.Code.Equals(roleCode));
    };

    public static Func<string, IUnitOfWork, Task<List<MasterDetail>>> GetMasterDetails = async (codeMaster, _unitOfWork) =>
    {
        var master = await _unitOfWork
            .Repository
            .MasterRepository
            .FirstAsync(s => s.Code.Equals(codeMaster), include: c => c.Include(i =>  i.MasterDetails));

        if (master == null)
            throw new EmployeeOrderProductException(Constants.Messages.VALUE_NULL);

        if (!master.MasterDetails.Any())
            throw new EmployeeOrderProductException(Constants.Messages.ITEMS_NOT_FOUND);

        return master.MasterDetails.ToList();
    };

    public static Func<string, IUnitOfWork, Task<MasterDetail>> GetMasterDetailByCode = async (codeMasterDetail, _unitOfWork) =>
    {
        var master = await _unitOfWork
            .Repository
            .MasterRepository
            .FirstAsync(
                s => s.MasterDetails.Select(s => s.Code).Contains(codeMasterDetail),
                include: c => c.Include(i => i.MasterDetails.Where(w => w.Code.Equals(codeMasterDetail)))
            );

        if (master == null)
            throw new EmployeeOrderProductException(Constants.Messages.VALUE_NULL);

        if (!master.MasterDetails.Any())
            throw new EmployeeOrderProductException(Constants.Messages.ITEMS_NOT_FOUND);

        return master.MasterDetails.First();
    };

    public static Func<List<Guid>, IUnitOfWork, Task<List<Product>>> GetProductsById = async (productIds, _unitOfWork) =>
    {
        var products =  await _unitOfWork
            .Repository
            .ProductRepository
            .GetAllAsync(p => productIds.Contains(p.Id));

        return products.ToList();
    };
}

