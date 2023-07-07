namespace DepositoHelados.Domain.Commons.Interfaces;

using System;
using System.Collections.Generic;

public interface IUpdateRepository<T> where T : class
{
    void Update(T t);
    void Update(IEnumerable<T> t);
    void DetachLocal(T t, Func<T, bool> predicate);
}

