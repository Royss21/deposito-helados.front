namespace DepositoHelados.Domain.Commons.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IRemoveRepository<T> where T : class
{
    void Remove(T t);
    void Remove(IEnumerable<T> t);
    void Remove(Expression<Func<T, bool>> predicate);
}

