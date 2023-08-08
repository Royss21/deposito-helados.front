namespace DepositoHelados.Domain.Commons.Interfaces;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DepositoHelados.Domain.Commons.Paged;
using Microsoft.EntityFrameworkCore.Query;

public interface IPagedRepository<T> where T : class
{
    Task<DataCollection<T>> GetPagedAsync(
        int page,
        int take,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    );

    DataCollection<T> GetPaged(
        int page,
        int take,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    );
}

