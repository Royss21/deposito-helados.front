
using Microsoft.EntityFrameworkCore.Storage;

namespace DepositoHelados.Infraestructure.UnitOfWork;

public interface IUnitOfWork
{
    void DetectChanges();
    void SaveChanges();
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync();
    void CommitTransaction();
    void RollbackTransaction();

    IUnitOfWorkRepository Repository { get; }
}