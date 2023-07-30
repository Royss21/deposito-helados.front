using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;

namespace DepositoHelados.Application.Services.EmployeeOrderProductService.Shared;

internal static class SharedFunctions
{
    
    public static Func<Guid, int, IUnitOfWork, Task<PersonRole>> GetPersonRole = async (Guid personId, int roleId, IUnitOfWork _unitOfWork) =>
    {
        var personEmployee = await _unitOfWork
                    .Repository
                    .PersonRepository
                    .FirstOrDefaultAsync(f =>
                        f.Id.Equals(personId) &&
                        f.PersonRoles.Select(c => c.RoleId).Contains(roleId),
                        include:
                            i => i.Include(s => s.PersonRoles)
                        );

        if (personEmployee == null)
            throw new EmployeeOrderProductException(Constants.VALUE_NULL);

        if (!personEmployee.PersonRoles.Any())
            throw new EmployeeOrderProductException(Constants.NO_ASSIGN_ROLE_EMPLOYEE.ReplaceArgs($"{personEmployee.FirstName} {personEmployee.LastName}"));

        return personEmployee.PersonRoles.First(f => f.RoleId == roleId);
    };
    

}

