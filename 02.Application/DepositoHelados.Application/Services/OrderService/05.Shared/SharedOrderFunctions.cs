using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using Microsoft.EntityFrameworkCore;

namespace DepositoHelados.Application.Services.OrderService._05.Shared;

internal static class SharedOrderFunctions
{

    public static Func<string, IUnitOfWork, Task<MasterDetail>> GetOrderType = async (codeMasterDetail,  _unitOfWork) =>
    {
        var master =  await _unitOfWork
            .Repository
            .MasterRepository
            .FirstAsync(
                s => s.MasterDetails.Select(s => s.Code).Contains(codeMasterDetail),
                include: c => c.Include(i => i.MasterDetails)
            );

        if (master == null)
            throw new EmployeeOrderProductException(Constants.Messages.VALUE_NULL);

        if (!master.MasterDetails.Any())
            throw new EmployeeOrderProductException(Constants.Messages.ITEMS_NOT_FOUND);

        return master.MasterDetails.First();
    };
}

