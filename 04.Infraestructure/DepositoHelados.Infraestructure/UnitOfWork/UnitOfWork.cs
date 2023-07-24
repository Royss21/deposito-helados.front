


using DepositoHelados.Infraestructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DepositoHelados.Infraestructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    public IUnitOfWorkRepository Repository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Repository = new UnitOfWorkRepository(_context);
    }

    #region Detect Changes
    public void DetectChanges()
    {
        _context.ChangeTracker.DetectChanges();
    }
    #endregion

    #region Save Changes
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Transactions
    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }
    #endregion

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

