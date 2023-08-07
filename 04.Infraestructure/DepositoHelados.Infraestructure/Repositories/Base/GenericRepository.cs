using DepositoHelados.Domain.Commons.Paged;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DepositoHelados.Infraestructure.Repositories.Base;

public abstract class GenericRepository<T> where T : class 
{
    protected ApplicationDbContext Context { get; }
    public GenericRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    protected IQueryable<T> PrepareQuery(
        IQueryable<T> query,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? take = null
    )
    {
        if (include != null)
            query = include(query);

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);

        if (take.HasValue)
            query = query.Take(Convert.ToInt32(take));

        return query;
    }

    public void DetachLocal(T t, Func<T, bool> predicate)
    {
        var local = Context.Set<T>().Local.FirstOrDefault(predicate);
        if (!Equals(local, default(T)))
        {
            Context.Entry(local).State = EntityState.Detached;
        }
        Context.Entry(t).State = EntityState.Modified;
    }

    #region Extras
    public virtual async Task<decimal?> SumAsync(
        Expression<Func<T, bool>> predicate = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate);

        return await ((IQueryable<decimal?>)query).SumAsync();
    }

    public virtual decimal? Sum(
        Expression<Func<T, bool>> predicate = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate);

        return ((IQueryable<decimal?>)query).Sum();
    }

    public virtual async Task<int> CountAsync(
        Expression<Func<T, bool>> predicate = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate);

        return await query.CountAsync();
    }

    public virtual int Count(
        Expression<Func<T, bool>> predicate = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate);

        return query.Count();
    }
    #endregion

    public virtual IQueryable<T> GetAllProject(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? take = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, null, orderBy, take);

        return query.AsNoTracking();
    }

    #region Get All
    public virtual IEnumerable<T> GetAll(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? take = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy, take);

        return query.ToList();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? take = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy, take);

        return await query.ToListAsync();
    }
    #endregion

    #region Paged
    public virtual async Task<DataCollection<T>> GetPagedAsync(
        int page,
        int take,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();
        var originalPages = page;

        page--;

        if (page > 0)
            page = page * take;

        query = PrepareQuery(query, predicate, include, orderBy);

        var items = await query.Skip(page).Take(take).ToListAsync();
        var total = await query.CountAsync();
        var pages = total > 0 ? Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / take)) : 0;

        return new DataCollection<T>(items, total, originalPages, pages);
    }

    public virtual DataCollection<T> GetPaged(
        int page,
        int take,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();
        var originalPages = page;

        page--;

        if (page > 0)
            page = page * take;

        query = PrepareQuery(query, predicate, include, orderBy);

        var items = query.Skip(page).Take(take).ToList();
        var total = query.Count();
        var pages = total > 0 ? Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total) / take)) : 0;

        return new DataCollection<T>(items, total, originalPages, pages);
    }
    #endregion

    #region First
    public virtual T First(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy);

        return query.First();
    }

    public virtual async Task<T> FirstAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy);

        return await query.FirstAsync();
    }

    public virtual T FirstOrDefault(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy);

        return query.FirstOrDefault();
    }

    public virtual async Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include, orderBy);

        return await query.FirstOrDefaultAsync();
    }
    #endregion

    #region Single
    public virtual T Single(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include);

        return query.Single();
    }

    public virtual async Task<T> SingleAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include);

        return await query.SingleAsync();
    }

    public virtual T SingleOrDefault(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include);

        return query.SingleOrDefault();
    }

    public virtual async Task<T> SingleOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        var query = Context.Set<T>().AsQueryable();

        query = PrepareQuery(query, predicate, include);

        return await query.SingleOrDefaultAsync();
    }
    #endregion

    #region Add
    public virtual void Add(T t)
    {
        Context.Add(t);
    }

    public virtual void Add(IEnumerable<T> t)
    {
        Context.AddRange(t);
    }

    public virtual async Task AddAsync(T t)
    {
        await Context.AddAsync(t);
    }

    public virtual async Task AddAsync(IEnumerable<T> t)
    {
        await Context.AddRangeAsync(t);
    }
    #endregion

    #region Remove

    public virtual void Remove(T t)
    {
        Context.Remove(t);
    }

    public virtual void Remove(Expression<Func<T, bool>> predicate)
    {
        var query = Context.Set<T>().Where(predicate).AsQueryable();
        foreach (var obj in query)
        {
            Remove(obj);
        }
    }

    public virtual void Remove(IEnumerable<T> t)
    {
        Context.RemoveRange(t);
    }
    #endregion

    #region Update
    public virtual void Update(T t)
    {
        Context.Update(t);
    }

    public virtual void Update(IEnumerable<T> t)
    {
        Context.UpdateRange(t);
    }
    #endregion

    public async Task<ValidationResult> ValidateEntityAsync ( T t,IValidator<T> validation)
    {
        var validationResultEntity = await validation.ValidateAsync(t);
        return validationResultEntity;
    }
}

